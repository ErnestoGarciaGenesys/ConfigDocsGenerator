using System;
using System.Collections.Generic;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using CfgDoc.Input;
using CfgDoc.CfgObjects;
using System.IO;

namespace CfgDoc.Output.WordRunBook
{
    class WordRunBookOutput : ICfgOutput
    {
        private static object missing = System.Reflection.Missing.Value;

        public string FilePath =
            Path.Combine(Directory.GetCurrentDirectory(), "RunBook.doc");

        private Word.Application word;
        private Word.Document doc;

        public void Generate(CfgSystem system)
        {
            createFile(FilePath, CfgDoc.Properties.Resources.WordRunBookTemplate);

            word = new Word.Application();
            word.Visible = true;
            doc = wordOpen(FilePath);

            ICollection<CfgHost> hosts = system.Hosts;

            string[] headers;
            string[] queries;

            wordGotoBookmark("HostsList");

            headers = new string[] {
                "DBID", "Name", "IP Address", "OS", "OS version", "LCA Port"
            };
            queries = new string[] {
                "dbid", "name", "ip_address", "(enum)os_type", "os_version", "lca_port"
            };

            wordAddCfgObjectTable(queries, headers, system.Hosts);

            wordGotoBookmark("ServersList");

            headers = new string[] {
                "Host name", "App name"
            };
            queries = new string[] {
                "host_dbid.name", "app_dbid.name"
            };

            wordAddCfgObjectTable(queries, headers, system.Servers);

            wordGotoBookmark("DapsList");

            headers = new string[] {
                "Host name", "App name"
            };
            queries = new string[] {
                "host_dbid.name", "app_dbid.name"
            };

            wordAddCfgObjectTable(queries, headers, system.Servers);
            
            wordGotoBookmark("DNsList");

            foreach (var switch_ in system.Switches)
            {
                wordSetStyleHeading(2);
                word.Selection.TypeText(switch_.Name);
                word.Selection.TypeParagraph();

                headers = new string[] {
                    "Number", "Type", "Annex options"
                };
                queries = new string[] {
                    "number_", "(enum)type", "(flexprops)cfg_flex_prop_DN"
                };

                wordAddCfgObjectTable(queries, headers, switch_.DNs);

                word.Selection.Move(Word.WdUnits.wdLine, 2);
            }

            wordGotoBookmark("TenantsList");

            foreach (var tenant in system.Tenants)
            {
                wordSetStyleHeading(2);
                word.Selection.TypeText(tenant.Name);
                word.Selection.TypeParagraph();

                wordSetStyleNormal();
                word.Selection.TypeText((string)CfgObjectUtil.Query(tenant, "(flexprops)cfg_flex_prop_Tenant"));
            }

            wordGotoBookmark("ServerOptions");

            foreach (CfgHost host in system.Hosts)
            {
                wordSetStyleHeading(2);
                word.Selection.TypeText(host.Name);
                word.Selection.TypeParagraph();

                foreach (CfgServer server in host.Servers)
                {
                    wordSetStyleHeading(3);
                    word.Selection.TypeText(server.Application.Name);
                    word.Selection.TypeParagraph();

                    wordSetStyleHeading(4);
                    word.Selection.TypeText("Options");
                    word.Selection.TypeParagraph();

                    wordSetStyleNormal();
                    word.Selection.TypeText(CfgObjectUtil.OptionsToString(server.Application.Options));

                    if (server.Application.FlexProperties.Count != 0)
                    {
                        wordSetStyleHeading(4);
                        word.Selection.TypeText("Annex options");
                        word.Selection.TypeParagraph();

                        wordSetStyleNormal();
                        word.Selection.TypeText(CfgObjectUtil.FlexPropsToString(server.Application.FlexProperties));
                    }
                }
            }

            wordGotoEnd();
        }

        private void wordSetStyleHeading(int level)
        {
            object[] wdStyleHeading = new object[10];
            wdStyleHeading[0] = Word.WdBuiltinStyle.wdStyleTitle;
            wdStyleHeading[1] = Word.WdBuiltinStyle.wdStyleHeading1;
            wdStyleHeading[2] = Word.WdBuiltinStyle.wdStyleHeading2;
            wdStyleHeading[3] = Word.WdBuiltinStyle.wdStyleHeading3;
            wdStyleHeading[4] = Word.WdBuiltinStyle.wdStyleHeading4;
            wdStyleHeading[5] = Word.WdBuiltinStyle.wdStyleHeading5;
            wdStyleHeading[6] = Word.WdBuiltinStyle.wdStyleHeading6;
            wdStyleHeading[7] = Word.WdBuiltinStyle.wdStyleHeading7;
            wdStyleHeading[8] = Word.WdBuiltinStyle.wdStyleHeading8;
            wdStyleHeading[9] = Word.WdBuiltinStyle.wdStyleHeading9;

            object style = word.ActiveDocument.Styles.get_Item(
                ref wdStyleHeading[level]);
            word.Selection.Paragraphs.set_Style(ref style);
        }

        private void wordSetStyleNormal()
        {
            object normal = Word.WdBuiltinStyle.wdStyleNormal;
            object style = word.ActiveDocument.Styles.get_Item(ref normal);
            word.Selection.Paragraphs.set_Style(ref style);
        }

        private void wordGotoEnd()
        {
            object wdStory = Word.WdUnits.wdStory;
            word.Selection.EndKey(ref wdStory, ref missing);
        }

        private void wordAddCfgObjectTable<TCfgObj>(
            string[] queries, string[] headers,
            ICollection<TCfgObj> cfgObjects)
        where TCfgObj: ICfgObject
        {
            Word.Table table = wordAddTable(cfgObjects.Count + 1, queries.Length);
            Word.Shading headerShading = table.Rows[1].Shading;
            headerShading.Texture = Word.WdTextureIndex.wdTextureSolid;

            bool moveRight = false;

            foreach (string header in headers)
            {
                if (moveRight)
                    wordMoveToCellRight();
                else
                    moveRight = true;

                word.Selection.TypeText(header);
            }

            foreach (ICfgObject cfgObject in cfgObjects)
            {
                foreach (string query in queries)
                {
                    wordMoveToCellRight();
                    word.Selection.TypeText(
                        CfgObjectUtil.Query(cfgObject, query).ToString());
                }
            }

            table.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitContent);
        }

        private void wordMoveToCellRight()
        {
            object wdCell = Word.WdUnits.wdCell;
            object one = 1;
            word.Selection.MoveRight(ref wdCell, ref one, ref missing);
        }

        private Word.Table wordAddTable(int rows, int cols)
        {
            return doc.Tables.Add(
                word.Selection.Range, rows, cols,
                ref missing, ref missing);
        }

        private void wordGotoBookmark(string bookmarkName)
        {
            object wdGoToBookmark = Word.WdGoToItem.wdGoToBookmark;
            object bookmarkNameObj = bookmarkName;
            word.Selection.GoTo(ref wdGoToBookmark,
                ref missing, ref missing, ref bookmarkNameObj);
        }

        private Word.Document wordNewDoc()
        {
            Word.Document doc = word.Documents.Add(
                ref missing, ref missing, ref missing, ref missing);
            return doc;
        }

        private Word.Document wordOpen(string path)
        {
            object filePathObj = new FileInfo(path).FullName;
            object readOnly = false;
            object isVisible = true;

            return word.Documents.Open(ref filePathObj,
                ref missing, ref readOnly, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref isVisible, ref missing,
                ref missing, ref missing, ref missing);
        }

        private void createFile(string path, byte[] bytes)
        {
            byte[] template = bytes;
            using (FileStream fileStream = File.Create(path))
            {
                fileStream.Write(template, 0, template.Length);
            }
        }
    }
}
