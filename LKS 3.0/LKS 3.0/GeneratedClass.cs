using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using Ap = DocumentFormat.OpenXml.ExtendedProperties;
using Vt = DocumentFormat.OpenXml.VariantTypes;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using M = DocumentFormat.OpenXml.Math;
using Ovml = DocumentFormat.OpenXml.Vml.Office;
using V = DocumentFormat.OpenXml.Vml;
using Ds = DocumentFormat.OpenXml.CustomXmlDataProperties;
using A = DocumentFormat.OpenXml.Drawing;

namespace LKS_3._0
{
    public class GeneratedClass
    {
        // Creates a WordprocessingDocument.
        public void CreatePackage(string filePath)
        {
            using (WordprocessingDocument package = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
            {
                CreateParts(package);
            }
        }

        // Adds child parts and generates content of the specified part.
        private void CreateParts(WordprocessingDocument document)
        {
            ExtendedFilePropertiesPart extendedFilePropertiesPart1 = document.AddNewPart<ExtendedFilePropertiesPart>("rId3");
            GenerateExtendedFilePropertiesPart1Content(extendedFilePropertiesPart1);

            MainDocumentPart mainDocumentPart1 = document.AddMainDocumentPart();
            GenerateMainDocumentPart1Content(mainDocumentPart1);

            DocumentSettingsPart documentSettingsPart1 = mainDocumentPart1.AddNewPart<DocumentSettingsPart>("rId3");
            GenerateDocumentSettingsPart1Content(documentSettingsPart1);

            StyleDefinitionsPart styleDefinitionsPart1 = mainDocumentPart1.AddNewPart<StyleDefinitionsPart>("rId2");
            GenerateStyleDefinitionsPart1Content(styleDefinitionsPart1);

            CustomXmlPart customXmlPart1 = mainDocumentPart1.AddNewPart<CustomXmlPart>("application/xml", "rId1");
            GenerateCustomXmlPart1Content(customXmlPart1);

            CustomXmlPropertiesPart customXmlPropertiesPart1 = customXmlPart1.AddNewPart<CustomXmlPropertiesPart>("rId1");
            GenerateCustomXmlPropertiesPart1Content(customXmlPropertiesPart1);

            ThemePart themePart1 = mainDocumentPart1.AddNewPart<ThemePart>("rId6");
            GenerateThemePart1Content(themePart1);

            FontTablePart fontTablePart1 = mainDocumentPart1.AddNewPart<FontTablePart>("rId5");
            GenerateFontTablePart1Content(fontTablePart1);

            WebSettingsPart webSettingsPart1 = mainDocumentPart1.AddNewPart<WebSettingsPart>("rId4");
            GenerateWebSettingsPart1Content(webSettingsPart1);

            SetPackageProperties(document);
        }

        // Generates content of extendedFilePropertiesPart1.
        private void GenerateExtendedFilePropertiesPart1Content(ExtendedFilePropertiesPart extendedFilePropertiesPart1)
        {
            Ap.Properties properties1 = new Ap.Properties();
            properties1.AddNamespaceDeclaration("vt", "http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes");
            Ap.Template template1 = new Ap.Template();
            template1.Text = "Normal.dotm";
            Ap.TotalTime totalTime1 = new Ap.TotalTime();
            totalTime1.Text = "0";
            Ap.Pages pages1 = new Ap.Pages();
            pages1.Text = "2";
            Ap.Words words1 = new Ap.Words();
            words1.Text = "268";
            Ap.Characters characters1 = new Ap.Characters();
            characters1.Text = "1533";
            Ap.Application application1 = new Ap.Application();
            application1.Text = "Microsoft Office Word";
            Ap.DocumentSecurity documentSecurity1 = new Ap.DocumentSecurity();
            documentSecurity1.Text = "0";
            Ap.Lines lines1 = new Ap.Lines();
            lines1.Text = "12";
            Ap.Paragraphs paragraphs1 = new Ap.Paragraphs();
            paragraphs1.Text = "3";
            Ap.ScaleCrop scaleCrop1 = new Ap.ScaleCrop();
            scaleCrop1.Text = "false";

            Ap.HeadingPairs headingPairs1 = new Ap.HeadingPairs();

            Vt.VTVector vTVector1 = new Vt.VTVector() { BaseType = Vt.VectorBaseValues.Variant, Size = (UInt32Value)2U };

            Vt.Variant variant1 = new Vt.Variant();
            Vt.VTLPSTR vTLPSTR1 = new Vt.VTLPSTR();
            vTLPSTR1.Text = "Название";

            variant1.Append(vTLPSTR1);

            Vt.Variant variant2 = new Vt.Variant();
            Vt.VTInt32 vTInt321 = new Vt.VTInt32();
            vTInt321.Text = "1";

            variant2.Append(vTInt321);

            vTVector1.Append(variant1);
            vTVector1.Append(variant2);

            headingPairs1.Append(vTVector1);

            Ap.TitlesOfParts titlesOfParts1 = new Ap.TitlesOfParts();

            Vt.VTVector vTVector2 = new Vt.VTVector() { BaseType = Vt.VectorBaseValues.Lpstr, Size = (UInt32Value)1U };
            Vt.VTLPSTR vTLPSTR2 = new Vt.VTLPSTR();
            vTLPSTR2.Text = "Приложение 8";

            vTVector2.Append(vTLPSTR2);

            titlesOfParts1.Append(vTVector2);
            Ap.Company company1 = new Ap.Company();
            company1.Text = "MYTH Inc";
            Ap.LinksUpToDate linksUpToDate1 = new Ap.LinksUpToDate();
            linksUpToDate1.Text = "false";
            Ap.CharactersWithSpaces charactersWithSpaces1 = new Ap.CharactersWithSpaces();
            charactersWithSpaces1.Text = "1798";
            Ap.SharedDocument sharedDocument1 = new Ap.SharedDocument();
            sharedDocument1.Text = "false";
            Ap.HyperlinksChanged hyperlinksChanged1 = new Ap.HyperlinksChanged();
            hyperlinksChanged1.Text = "false";
            Ap.ApplicationVersion applicationVersion1 = new Ap.ApplicationVersion();
            applicationVersion1.Text = "16.0000";

            properties1.Append(template1);
            properties1.Append(totalTime1);
            properties1.Append(pages1);
            properties1.Append(words1);
            properties1.Append(characters1);
            properties1.Append(application1);
            properties1.Append(documentSecurity1);
            properties1.Append(lines1);
            properties1.Append(paragraphs1);
            properties1.Append(scaleCrop1);
            properties1.Append(headingPairs1);
            properties1.Append(titlesOfParts1);
            properties1.Append(company1);
            properties1.Append(linksUpToDate1);
            properties1.Append(charactersWithSpaces1);
            properties1.Append(sharedDocument1);
            properties1.Append(hyperlinksChanged1);
            properties1.Append(applicationVersion1);

            extendedFilePropertiesPart1.Properties = properties1;
        }

        // Generates content of mainDocumentPart1.
        private void GenerateMainDocumentPart1Content(MainDocumentPart mainDocumentPart1)
        {
            Document document1 = new Document() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 w15 w16se wp14" } };
            document1.AddNamespaceDeclaration("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
            document1.AddNamespaceDeclaration("cx", "http://schemas.microsoft.com/office/drawing/2014/chartex");
            document1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            document1.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
            document1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            document1.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
            document1.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
            document1.AddNamespaceDeclaration("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
            document1.AddNamespaceDeclaration("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
            document1.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
            document1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            document1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            document1.AddNamespaceDeclaration("w15", "http://schemas.microsoft.com/office/word/2012/wordml");
            document1.AddNamespaceDeclaration("w16se", "http://schemas.microsoft.com/office/word/2015/wordml/symex");
            document1.AddNamespaceDeclaration("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
            document1.AddNamespaceDeclaration("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
            document1.AddNamespaceDeclaration("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
            document1.AddNamespaceDeclaration("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");

            Body body1 = new Body();

            Paragraph paragraph1 = new Paragraph() { RsidParagraphAddition = "005F2B37", RsidParagraphProperties = "005F2B37", RsidRunAdditionDefault = "005F2B37" };

            ParagraphProperties paragraphProperties1 = new ParagraphProperties();
            Justification justification1 = new Justification() { Val = JustificationValues.Right };

            paragraphProperties1.Append(justification1);
            BookmarkStart bookmarkStart1 = new BookmarkStart() { Name = "_GoBack", Id = "0" };
            BookmarkEnd bookmarkEnd1 = new BookmarkEnd() { Id = "0" };

            Run run1 = new Run();
            Text text1 = new Text();
            text1.Text = "Приложение 8";

            run1.Append(text1);

            paragraph1.Append(paragraphProperties1);
            paragraph1.Append(bookmarkStart1);
            paragraph1.Append(bookmarkEnd1);
            paragraph1.Append(run1);

            Paragraph paragraph2 = new Paragraph() { RsidParagraphMarkRevision = "005C7535", RsidParagraphAddition = "005C7535", RsidParagraphProperties = "005C7535", RsidRunAdditionDefault = "005C7535" };

            ParagraphProperties paragraphProperties2 = new ParagraphProperties();
            FrameProperties frameProperties1 = new FrameProperties() { Width = "1531", Height = (UInt32Value)1786U, HorizontalSpace = "181", Wrap = TextWrappingValues.Around, HorizontalPosition = HorizontalAnchorValues.Page, VerticalPosition = VerticalAnchorValues.Page, X = "14295", Y = "841", HeightType = HeightRuleValues.Exact };

            ParagraphBorders paragraphBorders1 = new ParagraphBorders();
            TopBorder topBorder1 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)6U, Space = (UInt32Value)1U };
            LeftBorder leftBorder1 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)6U, Space = (UInt32Value)1U };
            BottomBorder bottomBorder1 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)6U, Space = (UInt32Value)1U };
            RightBorder rightBorder1 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)6U, Space = (UInt32Value)1U };

            paragraphBorders1.Append(topBorder1);
            paragraphBorders1.Append(leftBorder1);
            paragraphBorders1.Append(bottomBorder1);
            paragraphBorders1.Append(rightBorder1);

            paragraphProperties2.Append(frameProperties1);
            paragraphProperties2.Append(paragraphBorders1);

            Run run2 = new Run() { RsidRunProperties = "005C7535" };
            Text text2 = new Text();
            text2.Text = "#";

            run2.Append(text2);

            Run run3 = new Run();

            RunProperties runProperties1 = new RunProperties();
            Languages languages1 = new Languages() { Val = "en-US" };

            runProperties1.Append(languages1);
            Text text3 = new Text();
            text3.Text = "photo";

            run3.Append(runProperties1);
            run3.Append(text3);

            paragraph2.Append(paragraphProperties2);
            paragraph2.Append(run2);
            paragraph2.Append(run3);

            Paragraph paragraph3 = new Paragraph() { RsidParagraphAddition = "006F635D", RsidParagraphProperties = "006F635D", RsidRunAdditionDefault = "006F635D" };

            ParagraphProperties paragraphProperties3 = new ParagraphProperties();
            Indentation indentation1 = new Indentation() { Left = "1416", Hanging = "1132" };
            Justification justification2 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties3.Append(indentation1);
            paragraphProperties3.Append(justification2);

            Run run4 = new Run();
            Text text4 = new Text();
            text4.Text = "ФЕДЕРАЛЬНОЕ ГОСУДАРСТВЕННОЕ БЮДЖЕТНОЕ ОБРАЗОВАТЕЛЬНОЕ УЧРЕЖДЕНИЕ";

            run4.Append(text4);

            paragraph3.Append(paragraphProperties3);
            paragraph3.Append(run4);

            Paragraph paragraph4 = new Paragraph() { RsidParagraphAddition = "006F635D", RsidParagraphProperties = "006F635D", RsidRunAdditionDefault = "006F635D" };

            ParagraphProperties paragraphProperties4 = new ParagraphProperties();
            Indentation indentation2 = new Indentation() { Left = "1416", Hanging = "1132" };
            Justification justification3 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties4.Append(indentation2);
            paragraphProperties4.Append(justification3);

            Run run5 = new Run();
            Text text5 = new Text();
            text5.Text = "ВЫСШЕГО ОБРАЗОВАНИЯ";

            run5.Append(text5);

            paragraph4.Append(paragraphProperties4);
            paragraph4.Append(run5);

            Paragraph paragraph5 = new Paragraph() { RsidParagraphAddition = "006F635D", RsidParagraphProperties = "006F635D", RsidRunAdditionDefault = "006F635D" };

            ParagraphProperties paragraphProperties5 = new ParagraphProperties();
            Indentation indentation3 = new Indentation() { Left = "1416", Hanging = "1132" };
            Justification justification4 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties1 = new ParagraphMarkRunProperties();
            Bold bold1 = new Bold();
            FontSize fontSize1 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript1 = new FontSizeComplexScript() { Val = "26" };

            paragraphMarkRunProperties1.Append(bold1);
            paragraphMarkRunProperties1.Append(fontSize1);
            paragraphMarkRunProperties1.Append(fontSizeComplexScript1);

            paragraphProperties5.Append(indentation3);
            paragraphProperties5.Append(justification4);
            paragraphProperties5.Append(paragraphMarkRunProperties1);

            Run run6 = new Run();

            RunProperties runProperties2 = new RunProperties();
            Bold bold2 = new Bold();
            FontSize fontSize2 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript2 = new FontSizeComplexScript() { Val = "26" };

            runProperties2.Append(bold2);
            runProperties2.Append(fontSize2);
            runProperties2.Append(fontSizeComplexScript2);
            Text text6 = new Text();
            text6.Text = "«МОСКОВСКИЙ АВИАЦИОННЫЙ ИНСТИТУТ";

            run6.Append(runProperties2);
            run6.Append(text6);

            paragraph5.Append(paragraphProperties5);
            paragraph5.Append(run6);

            Paragraph paragraph6 = new Paragraph() { RsidParagraphAddition = "006F635D", RsidParagraphProperties = "006F635D", RsidRunAdditionDefault = "006F635D" };

            ParagraphProperties paragraphProperties6 = new ParagraphProperties();
            Indentation indentation4 = new Indentation() { Left = "1416", Hanging = "1132" };
            Justification justification5 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties2 = new ParagraphMarkRunProperties();
            Bold bold3 = new Bold();

            paragraphMarkRunProperties2.Append(bold3);

            paragraphProperties6.Append(indentation4);
            paragraphProperties6.Append(justification5);
            paragraphProperties6.Append(paragraphMarkRunProperties2);

            Run run7 = new Run();

            RunProperties runProperties3 = new RunProperties();
            Bold bold4 = new Bold();
            FontSize fontSize3 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript3 = new FontSizeComplexScript() { Val = "26" };

            runProperties3.Append(bold4);
            runProperties3.Append(fontSize3);
            runProperties3.Append(fontSizeComplexScript3);
            Text text7 = new Text();
            text7.Text = "(национальный исследовательский университет)» (МАИ)";

            run7.Append(runProperties3);
            run7.Append(text7);

            paragraph6.Append(paragraphProperties6);
            paragraph6.Append(run7);

            Paragraph paragraph7 = new Paragraph() { RsidParagraphAddition = "005F2B37", RsidParagraphProperties = "004C4782", RsidRunAdditionDefault = "005F2B37" };

            ParagraphProperties paragraphProperties7 = new ParagraphProperties();
            Indentation indentation5 = new Indentation() { FirstLine = "708" };
            Justification justification6 = new Justification() { Val = JustificationValues.Right };

            paragraphProperties7.Append(indentation5);
            paragraphProperties7.Append(justification6);

            paragraph7.Append(paragraphProperties7);

            Paragraph paragraph8 = new Paragraph() { RsidParagraphAddition = "005F2B37", RsidParagraphProperties = "005F2B37", RsidRunAdditionDefault = "005F2B37" };

            ParagraphProperties paragraphProperties8 = new ParagraphProperties();
            Indentation indentation6 = new Indentation() { FirstLine = "708" };
            Justification justification7 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties8.Append(indentation6);
            paragraphProperties8.Append(justification7);

            Run run8 = new Run();
            Text text8 = new Text();
            text8.Text = "ЛИЧНАЯ КАРТОЧКА СТУДЕНТА";

            run8.Append(text8);

            paragraph8.Append(paragraphProperties8);
            paragraph8.Append(run8);

            Table table1 = new Table();

            TableProperties tableProperties1 = new TableProperties();
            TableWidth tableWidth1 = new TableWidth() { Width = "0", Type = TableWidthUnitValues.Auto };
            TableIndentation tableIndentation1 = new TableIndentation() { Width = 4680, Type = TableWidthUnitValues.Dxa };

            TableBorders tableBorders1 = new TableBorders();
            TopBorder topBorder2 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder2 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder2 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder2 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            InsideHorizontalBorder insideHorizontalBorder1 = new InsideHorizontalBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            InsideVerticalBorder insideVerticalBorder1 = new InsideVerticalBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableBorders1.Append(topBorder2);
            tableBorders1.Append(leftBorder2);
            tableBorders1.Append(bottomBorder2);
            tableBorders1.Append(rightBorder2);
            tableBorders1.Append(insideHorizontalBorder1);
            tableBorders1.Append(insideVerticalBorder1);
            TableLook tableLook1 = new TableLook() { Val = "01E0", FirstRow = true, LastRow = true, FirstColumn = true, LastColumn = true, NoHorizontalBand = false, NoVerticalBand = false };

            tableProperties1.Append(tableWidth1);
            tableProperties1.Append(tableIndentation1);
            tableProperties1.Append(tableBorders1);
            tableProperties1.Append(tableLook1);

            TableGrid tableGrid1 = new TableGrid();
            GridColumn gridColumn1 = new GridColumn() { Width = "2268" };
            GridColumn gridColumn2 = new GridColumn() { Width = "3060" };

            tableGrid1.Append(gridColumn1);
            tableGrid1.Append(gridColumn2);

            TableRow tableRow1 = new TableRow() { RsidTableRowAddition = "005F2B37", RsidTableRowProperties = "00E96696" };

            TableCell tableCell1 = new TableCell();

            TableCellProperties tableCellProperties1 = new TableCellProperties();
            TableCellWidth tableCellWidth1 = new TableCellWidth() { Width = "2268", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders1 = new TableCellBorders();
            TopBorder topBorder3 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder3 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder3 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder3 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders1.Append(topBorder3);
            tableCellBorders1.Append(leftBorder3);
            tableCellBorders1.Append(bottomBorder3);
            tableCellBorders1.Append(rightBorder3);
            Shading shading1 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties1.Append(tableCellWidth1);
            tableCellProperties1.Append(tableCellBorders1);
            tableCellProperties1.Append(shading1);

            Paragraph paragraph9 = new Paragraph() { RsidParagraphAddition = "005F2B37", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "005F2B37" };

            ParagraphProperties paragraphProperties9 = new ParagraphProperties();
            Justification justification8 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties9.Append(justification8);

            Run run9 = new Run();
            Text text9 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text9.Text = "Дата приёма ";

            run9.Append(text9);

            paragraph9.Append(paragraphProperties9);
            paragraph9.Append(run9);

            tableCell1.Append(tableCellProperties1);
            tableCell1.Append(paragraph9);

            TableCell tableCell2 = new TableCell();

            TableCellProperties tableCellProperties2 = new TableCellProperties();
            TableCellWidth tableCellWidth2 = new TableCellWidth() { Width = "3060", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders2 = new TableCellBorders();
            TopBorder topBorder4 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder4 = new LeftBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder4 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders2.Append(topBorder4);
            tableCellBorders2.Append(leftBorder4);
            tableCellBorders2.Append(rightBorder4);
            Shading shading2 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties2.Append(tableCellWidth2);
            tableCellProperties2.Append(tableCellBorders2);
            tableCellProperties2.Append(shading2);

            Paragraph paragraph10 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "005F2B37", RsidParagraphProperties = "005F2B37", RsidRunAdditionDefault = "005F2B37" };

            ParagraphProperties paragraphProperties10 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties3 = new ParagraphMarkRunProperties();
            Italic italic1 = new Italic();
            FontSize fontSize4 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript4 = new FontSizeComplexScript() { Val = "26" };
            Languages languages2 = new Languages() { Val = "en-US" };

            paragraphMarkRunProperties3.Append(italic1);
            paragraphMarkRunProperties3.Append(fontSize4);
            paragraphMarkRunProperties3.Append(fontSizeComplexScript4);
            paragraphMarkRunProperties3.Append(languages2);

            paragraphProperties10.Append(paragraphMarkRunProperties3);

            Run run10 = new Run() { RsidRunProperties = "00E96696" };

            RunProperties runProperties4 = new RunProperties();
            Italic italic2 = new Italic();
            FontSize fontSize5 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript5 = new FontSizeComplexScript() { Val = "26" };

            runProperties4.Append(italic2);
            runProperties4.Append(fontSize5);
            runProperties4.Append(fontSizeComplexScript5);
            Text text10 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text10.Text = "«1» сентября ";

            run10.Append(runProperties4);
            run10.Append(text10);

            Run run11 = new Run() { RsidRunProperties = "00E96696" };

            RunProperties runProperties5 = new RunProperties();
            Italic italic3 = new Italic();
            FontSize fontSize6 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript6 = new FontSizeComplexScript() { Val = "26" };
            Languages languages3 = new Languages() { Val = "en-US" };

            runProperties5.Append(italic3);
            runProperties5.Append(fontSize6);
            runProperties5.Append(fontSizeComplexScript6);
            runProperties5.Append(languages3);
            Text text11 = new Text();
            text11.Text = "#";

            run11.Append(runProperties5);
            run11.Append(text11);

            Run run12 = new Run() { RsidRunProperties = "00E96696", RsidRunAddition = "00773784" };

            RunProperties runProperties6 = new RunProperties();
            Italic italic4 = new Italic();
            FontSize fontSize7 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript7 = new FontSizeComplexScript() { Val = "26" };
            Languages languages4 = new Languages() { Val = "en-US" };

            runProperties6.Append(italic4);
            runProperties6.Append(fontSize7);
            runProperties6.Append(fontSizeComplexScript7);
            runProperties6.Append(languages4);
            Text text12 = new Text();
            text12.Text = "enter";

            run12.Append(runProperties6);
            run12.Append(text12);

            paragraph10.Append(paragraphProperties10);
            paragraph10.Append(run10);
            paragraph10.Append(run11);
            paragraph10.Append(run12);

            tableCell2.Append(tableCellProperties2);
            tableCell2.Append(paragraph10);

            tableRow1.Append(tableCell1);
            tableRow1.Append(tableCell2);

            table1.Append(tableProperties1);
            table1.Append(tableGrid1);
            table1.Append(tableRow1);

            Paragraph paragraph11 = new Paragraph() { RsidParagraphAddition = "005F2B37", RsidParagraphProperties = "005F2B37", RsidRunAdditionDefault = "005F2B37" };

            ParagraphProperties paragraphProperties11 = new ParagraphProperties();
            Indentation indentation7 = new Indentation() { FirstLine = "708" };
            Justification justification9 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties11.Append(indentation7);
            paragraphProperties11.Append(justification9);

            paragraph11.Append(paragraphProperties11);

            Paragraph paragraph12 = new Paragraph() { RsidParagraphMarkRevision = "00FE7005", RsidParagraphAddition = "004C4782", RsidParagraphProperties = "005F2B37", RsidRunAdditionDefault = "004C4782" };

            ParagraphProperties paragraphProperties12 = new ParagraphProperties();
            Indentation indentation8 = new Indentation() { FirstLine = "708" };
            Justification justification10 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties4 = new ParagraphMarkRunProperties();
            FontSize fontSize8 = new FontSize() { Val = "20" };
            FontSizeComplexScript fontSizeComplexScript8 = new FontSizeComplexScript() { Val = "20" };

            paragraphMarkRunProperties4.Append(fontSize8);
            paragraphMarkRunProperties4.Append(fontSizeComplexScript8);

            paragraphProperties12.Append(indentation8);
            paragraphProperties12.Append(justification10);
            paragraphProperties12.Append(paragraphMarkRunProperties4);

            paragraph12.Append(paragraphProperties12);

            Paragraph paragraph13 = new Paragraph() { RsidParagraphAddition = "005F2B37", RsidParagraphProperties = "005F2B37", RsidRunAdditionDefault = "005F2B37" };

            ParagraphProperties paragraphProperties13 = new ParagraphProperties();
            Indentation indentation9 = new Indentation() { FirstLine = "708" };
            Justification justification11 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties13.Append(indentation9);
            paragraphProperties13.Append(justification11);

            paragraph13.Append(paragraphProperties13);

            Table table2 = new Table();

            TableProperties tableProperties2 = new TableProperties();
            TableWidth tableWidth2 = new TableWidth() { Width = "0", Type = TableWidthUnitValues.Auto };

            TableBorders tableBorders2 = new TableBorders();
            TopBorder topBorder5 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder5 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder4 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder5 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            InsideHorizontalBorder insideHorizontalBorder2 = new InsideHorizontalBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            InsideVerticalBorder insideVerticalBorder2 = new InsideVerticalBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableBorders2.Append(topBorder5);
            tableBorders2.Append(leftBorder5);
            tableBorders2.Append(bottomBorder4);
            tableBorders2.Append(rightBorder5);
            tableBorders2.Append(insideHorizontalBorder2);
            tableBorders2.Append(insideVerticalBorder2);
            TableLayout tableLayout1 = new TableLayout() { Type = TableLayoutValues.Fixed };
            TableLook tableLook2 = new TableLook() { Val = "01E0", FirstRow = true, LastRow = true, FirstColumn = true, LastColumn = true, NoHorizontalBand = false, NoVerticalBand = false };

            tableProperties2.Append(tableWidth2);
            tableProperties2.Append(tableBorders2);
            tableProperties2.Append(tableLayout1);
            tableProperties2.Append(tableLook2);

            TableGrid tableGrid2 = new TableGrid();
            GridColumn gridColumn3 = new GridColumn() { Width = "828" };
            GridColumn gridColumn4 = new GridColumn() { Width = "324" };
            GridColumn gridColumn5 = new GridColumn() { Width = "36" };
            GridColumn gridColumn6 = new GridColumn() { Width = "360" };
            GridColumn gridColumn7 = new GridColumn() { Width = "360" };
            GridColumn gridColumn8 = new GridColumn() { Width = "180" };
            GridColumn gridColumn9 = new GridColumn() { Width = "1080" };
            GridColumn gridColumn10 = new GridColumn() { Width = "180" };
            GridColumn gridColumn11 = new GridColumn() { Width = "180" };
            GridColumn gridColumn12 = new GridColumn() { Width = "180" };
            GridColumn gridColumn13 = new GridColumn() { Width = "360" };
            GridColumn gridColumn14 = new GridColumn() { Width = "360" };
            GridColumn gridColumn15 = new GridColumn() { Width = "180" };
            GridColumn gridColumn16 = new GridColumn() { Width = "478" };
            GridColumn gridColumn17 = new GridColumn() { Width = "2077" };
            GridColumn gridColumn18 = new GridColumn() { Width = "505" };
            GridColumn gridColumn19 = new GridColumn() { Width = "2520" };
            GridColumn gridColumn20 = new GridColumn() { Width = "360" };
            GridColumn gridColumn21 = new GridColumn() { Width = "180" };
            GridColumn gridColumn22 = new GridColumn() { Width = "764" };
            GridColumn gridColumn23 = new GridColumn() { Width = "27" };
            GridColumn gridColumn24 = new GridColumn() { Width = "468" };
            GridColumn gridColumn25 = new GridColumn() { Width = "180" };
            GridColumn gridColumn26 = new GridColumn() { Width = "1981" };

            tableGrid2.Append(gridColumn3);
            tableGrid2.Append(gridColumn4);
            tableGrid2.Append(gridColumn5);
            tableGrid2.Append(gridColumn6);
            tableGrid2.Append(gridColumn7);
            tableGrid2.Append(gridColumn8);
            tableGrid2.Append(gridColumn9);
            tableGrid2.Append(gridColumn10);
            tableGrid2.Append(gridColumn11);
            tableGrid2.Append(gridColumn12);
            tableGrid2.Append(gridColumn13);
            tableGrid2.Append(gridColumn14);
            tableGrid2.Append(gridColumn15);
            tableGrid2.Append(gridColumn16);
            tableGrid2.Append(gridColumn17);
            tableGrid2.Append(gridColumn18);
            tableGrid2.Append(gridColumn19);
            tableGrid2.Append(gridColumn20);
            tableGrid2.Append(gridColumn21);
            tableGrid2.Append(gridColumn22);
            tableGrid2.Append(gridColumn23);
            tableGrid2.Append(gridColumn24);
            tableGrid2.Append(gridColumn25);
            tableGrid2.Append(gridColumn26);

            TableRow tableRow2 = new TableRow() { RsidTableRowAddition = "00284D35", RsidTableRowProperties = "00E96696" };

            TableCell tableCell3 = new TableCell();

            TableCellProperties tableCellProperties3 = new TableCellProperties();
            TableCellWidth tableCellWidth3 = new TableCellWidth() { Width = "1188", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan1 = new GridSpan() { Val = 3 };

            TableCellBorders tableCellBorders3 = new TableCellBorders();
            TopBorder topBorder6 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder6 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder5 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder6 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders3.Append(topBorder6);
            tableCellBorders3.Append(leftBorder6);
            tableCellBorders3.Append(bottomBorder5);
            tableCellBorders3.Append(rightBorder6);
            Shading shading3 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties3.Append(tableCellWidth3);
            tableCellProperties3.Append(gridSpan1);
            tableCellProperties3.Append(tableCellBorders3);
            tableCellProperties3.Append(shading3);

            Paragraph paragraph14 = new Paragraph() { RsidParagraphAddition = "00284D35", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D35" };

            ParagraphProperties paragraphProperties14 = new ParagraphProperties();
            Justification justification12 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties14.Append(justification12);

            Run run13 = new Run();
            Text text13 = new Text();
            text13.Text = "Фамилия";

            run13.Append(text13);

            paragraph14.Append(paragraphProperties14);
            paragraph14.Append(run13);

            tableCell3.Append(tableCellProperties3);
            tableCell3.Append(paragraph14);

            TableCell tableCell4 = new TableCell();

            TableCellProperties tableCellProperties4 = new TableCellProperties();
            TableCellWidth tableCellWidth4 = new TableCellWidth() { Width = "5975", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan2 = new GridSpan() { Val = 12 };

            TableCellBorders tableCellBorders4 = new TableCellBorders();
            TopBorder topBorder7 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder7 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder6 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder7 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders4.Append(topBorder7);
            tableCellBorders4.Append(leftBorder7);
            tableCellBorders4.Append(bottomBorder6);
            tableCellBorders4.Append(rightBorder7);
            Shading shading4 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties4.Append(tableCellWidth4);
            tableCellProperties4.Append(gridSpan2);
            tableCellProperties4.Append(tableCellBorders4);
            tableCellProperties4.Append(shading4);

            Paragraph paragraph15 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "00284D35", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00DB2712" };

            ParagraphProperties paragraphProperties15 = new ParagraphProperties();
            Justification justification13 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties5 = new ParagraphMarkRunProperties();
            Italic italic5 = new Italic();
            FontSize fontSize9 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript9 = new FontSizeComplexScript() { Val = "26" };
            Languages languages5 = new Languages() { Val = "en-US" };

            paragraphMarkRunProperties5.Append(italic5);
            paragraphMarkRunProperties5.Append(fontSize9);
            paragraphMarkRunProperties5.Append(fontSizeComplexScript9);
            paragraphMarkRunProperties5.Append(languages5);

            paragraphProperties15.Append(justification13);
            paragraphProperties15.Append(paragraphMarkRunProperties5);

            Run run14 = new Run() { RsidRunProperties = "00E96696" };

            RunProperties runProperties7 = new RunProperties();
            Italic italic6 = new Italic();
            FontSize fontSize10 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript10 = new FontSizeComplexScript() { Val = "26" };
            Languages languages6 = new Languages() { Val = "en-US" };

            runProperties7.Append(italic6);
            runProperties7.Append(fontSize10);
            runProperties7.Append(fontSizeComplexScript10);
            runProperties7.Append(languages6);
            Text text14 = new Text();
            text14.Text = "#surname";

            run14.Append(runProperties7);
            run14.Append(text14);

            paragraph15.Append(paragraphProperties15);
            paragraph15.Append(run14);

            tableCell4.Append(tableCellProperties4);
            tableCell4.Append(paragraph15);

            TableCell tableCell5 = new TableCell();

            TableCellProperties tableCellProperties5 = new TableCellProperties();
            TableCellWidth tableCellWidth5 = new TableCellWidth() { Width = "505", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders5 = new TableCellBorders();
            TopBorder topBorder8 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder8 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder7 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder8 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders5.Append(topBorder8);
            tableCellBorders5.Append(leftBorder8);
            tableCellBorders5.Append(bottomBorder7);
            tableCellBorders5.Append(rightBorder8);
            Shading shading5 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties5.Append(tableCellWidth5);
            tableCellProperties5.Append(tableCellBorders5);
            tableCellProperties5.Append(shading5);

            Paragraph paragraph16 = new Paragraph() { RsidParagraphMarkRevision = "00284D35", RsidParagraphAddition = "00284D35", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D35" };

            ParagraphProperties paragraphProperties16 = new ParagraphProperties();
            Justification justification14 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties16.Append(justification14);

            paragraph16.Append(paragraphProperties16);

            tableCell5.Append(tableCellProperties5);
            tableCell5.Append(paragraph16);

            TableCell tableCell6 = new TableCell();

            TableCellProperties tableCellProperties6 = new TableCellProperties();
            TableCellWidth tableCellWidth6 = new TableCellWidth() { Width = "4319", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan3 = new GridSpan() { Val = 6 };

            TableCellBorders tableCellBorders6 = new TableCellBorders();
            TopBorder topBorder9 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder9 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder8 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder9 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders6.Append(topBorder9);
            tableCellBorders6.Append(leftBorder9);
            tableCellBorders6.Append(bottomBorder8);
            tableCellBorders6.Append(rightBorder9);
            Shading shading6 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties6.Append(tableCellWidth6);
            tableCellProperties6.Append(gridSpan3);
            tableCellProperties6.Append(tableCellBorders6);
            tableCellProperties6.Append(shading6);

            Paragraph paragraph17 = new Paragraph() { RsidParagraphMarkRevision = "00284D35", RsidParagraphAddition = "00284D35", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D35" };

            ParagraphProperties paragraphProperties17 = new ParagraphProperties();
            Indentation indentation10 = new Indentation() { Left = "-108", Right = "-108" };
            Justification justification15 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties17.Append(indentation10);
            paragraphProperties17.Append(justification15);

            Run run15 = new Run() { RsidRunProperties = "00284D35" };
            Text text15 = new Text();
            text15.Text = "Начало обучения на военной кафедре:";

            run15.Append(text15);

            paragraph17.Append(paragraphProperties17);
            paragraph17.Append(run15);

            tableCell6.Append(tableCellProperties6);
            tableCell6.Append(paragraph17);

            TableCell tableCell7 = new TableCell();

            TableCellProperties tableCellProperties7 = new TableCellProperties();
            TableCellWidth tableCellWidth7 = new TableCellWidth() { Width = "2161", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan4 = new GridSpan() { Val = 2 };

            TableCellBorders tableCellBorders7 = new TableCellBorders();
            TopBorder topBorder10 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder10 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder9 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder10 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders7.Append(topBorder10);
            tableCellBorders7.Append(leftBorder10);
            tableCellBorders7.Append(bottomBorder9);
            tableCellBorders7.Append(rightBorder10);
            Shading shading7 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties7.Append(tableCellWidth7);
            tableCellProperties7.Append(gridSpan4);
            tableCellProperties7.Append(tableCellBorders7);
            tableCellProperties7.Append(shading7);

            Paragraph paragraph18 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "00284D35", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00DB2712" };

            ParagraphProperties paragraphProperties18 = new ParagraphProperties();
            Justification justification16 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties6 = new ParagraphMarkRunProperties();
            Italic italic7 = new Italic();
            FontSize fontSize11 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript11 = new FontSizeComplexScript() { Val = "26" };
            Languages languages7 = new Languages() { Val = "en-US" };

            paragraphMarkRunProperties6.Append(italic7);
            paragraphMarkRunProperties6.Append(fontSize11);
            paragraphMarkRunProperties6.Append(fontSizeComplexScript11);
            paragraphMarkRunProperties6.Append(languages7);

            paragraphProperties18.Append(justification16);
            paragraphProperties18.Append(paragraphMarkRunProperties6);

            Run run16 = new Run() { RsidRunProperties = "00E96696" };

            RunProperties runProperties8 = new RunProperties();
            Italic italic8 = new Italic();
            FontSize fontSize12 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript12 = new FontSizeComplexScript() { Val = "26" };
            Languages languages8 = new Languages() { Val = "en-US" };

            runProperties8.Append(italic8);
            runProperties8.Append(fontSize12);
            runProperties8.Append(fontSizeComplexScript12);
            runProperties8.Append(languages8);
            Text text16 = new Text();
            text16.Text = "#wk_begin";

            run16.Append(runProperties8);
            run16.Append(text16);

            Run run17 = new Run() { RsidRunProperties = "00E96696", RsidRunAddition = "00284D35" };

            RunProperties runProperties9 = new RunProperties();
            Italic italic9 = new Italic();
            FontSize fontSize13 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript13 = new FontSizeComplexScript() { Val = "26" };

            runProperties9.Append(italic9);
            runProperties9.Append(fontSize13);
            runProperties9.Append(fontSizeComplexScript13);
            Text text17 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text17.Text = " ";

            run17.Append(runProperties9);
            run17.Append(text17);

            paragraph18.Append(paragraphProperties18);
            paragraph18.Append(run16);
            paragraph18.Append(run17);

            tableCell7.Append(tableCellProperties7);
            tableCell7.Append(paragraph18);

            tableRow2.Append(tableCell3);
            tableRow2.Append(tableCell4);
            tableRow2.Append(tableCell5);
            tableRow2.Append(tableCell6);
            tableRow2.Append(tableCell7);

            TableRow tableRow3 = new TableRow() { RsidTableRowAddition = "00284D35", RsidTableRowProperties = "00E96696" };

            TableRowProperties tableRowProperties1 = new TableRowProperties();
            TableRowHeight tableRowHeight1 = new TableRowHeight() { Val = (UInt32Value)130U };

            tableRowProperties1.Append(tableRowHeight1);

            TableCell tableCell8 = new TableCell();

            TableCellProperties tableCellProperties8 = new TableCellProperties();
            TableCellWidth tableCellWidth8 = new TableCellWidth() { Width = "828", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders8 = new TableCellBorders();
            TopBorder topBorder11 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder11 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder10 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder11 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders8.Append(topBorder11);
            tableCellBorders8.Append(leftBorder11);
            tableCellBorders8.Append(bottomBorder10);
            tableCellBorders8.Append(rightBorder11);
            Shading shading8 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties8.Append(tableCellWidth8);
            tableCellProperties8.Append(tableCellBorders8);
            tableCellProperties8.Append(shading8);

            Paragraph paragraph19 = new Paragraph() { RsidParagraphAddition = "00284D35", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D35" };

            ParagraphProperties paragraphProperties19 = new ParagraphProperties();
            Justification justification17 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties19.Append(justification17);

            Run run18 = new Run();
            Text text18 = new Text();
            text18.Text = "Имя";

            run18.Append(text18);

            paragraph19.Append(paragraphProperties19);
            paragraph19.Append(run18);

            tableCell8.Append(tableCellProperties8);
            tableCell8.Append(paragraph19);

            TableCell tableCell9 = new TableCell();

            TableCellProperties tableCellProperties9 = new TableCellProperties();
            TableCellWidth tableCellWidth9 = new TableCellWidth() { Width = "2340", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan5 = new GridSpan() { Val = 6 };

            TableCellBorders tableCellBorders9 = new TableCellBorders();
            TopBorder topBorder12 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder12 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder11 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder12 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders9.Append(topBorder12);
            tableCellBorders9.Append(leftBorder12);
            tableCellBorders9.Append(bottomBorder11);
            tableCellBorders9.Append(rightBorder12);
            Shading shading9 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties9.Append(tableCellWidth9);
            tableCellProperties9.Append(gridSpan5);
            tableCellProperties9.Append(tableCellBorders9);
            tableCellProperties9.Append(shading9);

            Paragraph paragraph20 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "00284D35", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00DB2712" };

            ParagraphProperties paragraphProperties20 = new ParagraphProperties();
            Justification justification18 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties7 = new ParagraphMarkRunProperties();
            Italic italic10 = new Italic();
            FontSize fontSize14 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript14 = new FontSizeComplexScript() { Val = "28" };
            Languages languages9 = new Languages() { Val = "en-US" };

            paragraphMarkRunProperties7.Append(italic10);
            paragraphMarkRunProperties7.Append(fontSize14);
            paragraphMarkRunProperties7.Append(fontSizeComplexScript14);
            paragraphMarkRunProperties7.Append(languages9);

            paragraphProperties20.Append(justification18);
            paragraphProperties20.Append(paragraphMarkRunProperties7);

            Run run19 = new Run() { RsidRunProperties = "00E96696" };

            RunProperties runProperties10 = new RunProperties();
            Italic italic11 = new Italic();
            FontSize fontSize15 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript15 = new FontSizeComplexScript() { Val = "28" };
            Languages languages10 = new Languages() { Val = "en-US" };

            runProperties10.Append(italic11);
            runProperties10.Append(fontSize15);
            runProperties10.Append(fontSizeComplexScript15);
            runProperties10.Append(languages10);
            Text text19 = new Text();
            text19.Text = "#name";

            run19.Append(runProperties10);
            run19.Append(text19);

            paragraph20.Append(paragraphProperties20);
            paragraph20.Append(run19);

            tableCell9.Append(tableCellProperties9);
            tableCell9.Append(paragraph20);

            TableCell tableCell10 = new TableCell();

            TableCellProperties tableCellProperties10 = new TableCellProperties();
            TableCellWidth tableCellWidth10 = new TableCellWidth() { Width = "1260", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan6 = new GridSpan() { Val = 5 };

            TableCellBorders tableCellBorders10 = new TableCellBorders();
            TopBorder topBorder13 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder13 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder12 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder13 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders10.Append(topBorder13);
            tableCellBorders10.Append(leftBorder13);
            tableCellBorders10.Append(bottomBorder12);
            tableCellBorders10.Append(rightBorder13);
            Shading shading10 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties10.Append(tableCellWidth10);
            tableCellProperties10.Append(gridSpan6);
            tableCellProperties10.Append(tableCellBorders10);
            tableCellProperties10.Append(shading10);

            Paragraph paragraph21 = new Paragraph() { RsidParagraphAddition = "00284D35", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D35" };

            ParagraphProperties paragraphProperties21 = new ParagraphProperties();
            Justification justification19 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties21.Append(justification19);

            Run run20 = new Run();
            Text text20 = new Text();
            text20.Text = "Отчество";

            run20.Append(text20);

            paragraph21.Append(paragraphProperties21);
            paragraph21.Append(run20);

            tableCell10.Append(tableCellProperties10);
            tableCell10.Append(paragraph21);

            TableCell tableCell11 = new TableCell();

            TableCellProperties tableCellProperties11 = new TableCellProperties();
            TableCellWidth tableCellWidth11 = new TableCellWidth() { Width = "2735", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan7 = new GridSpan() { Val = 3 };

            TableCellBorders tableCellBorders11 = new TableCellBorders();
            TopBorder topBorder14 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder14 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder13 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder14 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders11.Append(topBorder14);
            tableCellBorders11.Append(leftBorder14);
            tableCellBorders11.Append(bottomBorder13);
            tableCellBorders11.Append(rightBorder14);
            Shading shading11 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties11.Append(tableCellWidth11);
            tableCellProperties11.Append(gridSpan7);
            tableCellProperties11.Append(tableCellBorders11);
            tableCellProperties11.Append(shading11);

            Paragraph paragraph22 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "00284D35", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00DB2712" };

            ParagraphProperties paragraphProperties22 = new ParagraphProperties();
            Justification justification20 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties8 = new ParagraphMarkRunProperties();
            Italic italic12 = new Italic();
            FontSize fontSize16 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript16 = new FontSizeComplexScript() { Val = "28" };
            Languages languages11 = new Languages() { Val = "en-US" };

            paragraphMarkRunProperties8.Append(italic12);
            paragraphMarkRunProperties8.Append(fontSize16);
            paragraphMarkRunProperties8.Append(fontSizeComplexScript16);
            paragraphMarkRunProperties8.Append(languages11);

            paragraphProperties22.Append(justification20);
            paragraphProperties22.Append(paragraphMarkRunProperties8);

            Run run21 = new Run() { RsidRunProperties = "00E96696" };

            RunProperties runProperties11 = new RunProperties();
            Italic italic13 = new Italic();
            FontSize fontSize17 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript17 = new FontSizeComplexScript() { Val = "28" };
            Languages languages12 = new Languages() { Val = "en-US" };

            runProperties11.Append(italic13);
            runProperties11.Append(fontSize17);
            runProperties11.Append(fontSizeComplexScript17);
            runProperties11.Append(languages12);
            Text text21 = new Text();
            text21.Text = "#oname";

            run21.Append(runProperties11);
            run21.Append(text21);

            paragraph22.Append(paragraphProperties22);
            paragraph22.Append(run21);

            tableCell11.Append(tableCellProperties11);
            tableCell11.Append(paragraph22);

            TableCell tableCell12 = new TableCell();

            TableCellProperties tableCellProperties12 = new TableCellProperties();
            TableCellWidth tableCellWidth12 = new TableCellWidth() { Width = "505", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders12 = new TableCellBorders();
            TopBorder topBorder15 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder15 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder14 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder15 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders12.Append(topBorder15);
            tableCellBorders12.Append(leftBorder15);
            tableCellBorders12.Append(bottomBorder14);
            tableCellBorders12.Append(rightBorder15);
            Shading shading12 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties12.Append(tableCellWidth12);
            tableCellProperties12.Append(tableCellBorders12);
            tableCellProperties12.Append(shading12);

            Paragraph paragraph23 = new Paragraph() { RsidParagraphAddition = "00284D35", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D35" };

            ParagraphProperties paragraphProperties23 = new ParagraphProperties();
            Justification justification21 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties23.Append(justification21);

            paragraph23.Append(paragraphProperties23);

            tableCell12.Append(tableCellProperties12);
            tableCell12.Append(paragraph23);

            TableCell tableCell13 = new TableCell();

            TableCellProperties tableCellProperties13 = new TableCellProperties();
            TableCellWidth tableCellWidth13 = new TableCellWidth() { Width = "4319", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan8 = new GridSpan() { Val = 6 };

            TableCellBorders tableCellBorders13 = new TableCellBorders();
            TopBorder topBorder16 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder16 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder15 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder16 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders13.Append(topBorder16);
            tableCellBorders13.Append(leftBorder16);
            tableCellBorders13.Append(bottomBorder15);
            tableCellBorders13.Append(rightBorder16);
            Shading shading13 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties13.Append(tableCellWidth13);
            tableCellProperties13.Append(gridSpan8);
            tableCellProperties13.Append(tableCellBorders13);
            tableCellProperties13.Append(shading13);

            Paragraph paragraph24 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "00284D35", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D35" };

            ParagraphProperties paragraphProperties24 = new ParagraphProperties();
            Justification justification22 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties9 = new ParagraphMarkRunProperties();
            FontSize fontSize18 = new FontSize() { Val = "12" };
            FontSizeComplexScript fontSizeComplexScript18 = new FontSizeComplexScript() { Val = "12" };

            paragraphMarkRunProperties9.Append(fontSize18);
            paragraphMarkRunProperties9.Append(fontSizeComplexScript18);

            paragraphProperties24.Append(justification22);
            paragraphProperties24.Append(paragraphMarkRunProperties9);

            paragraph24.Append(paragraphProperties24);

            tableCell13.Append(tableCellProperties13);
            tableCell13.Append(paragraph24);

            TableCell tableCell14 = new TableCell();

            TableCellProperties tableCellProperties14 = new TableCellProperties();
            TableCellWidth tableCellWidth14 = new TableCellWidth() { Width = "2161", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan9 = new GridSpan() { Val = 2 };

            TableCellBorders tableCellBorders14 = new TableCellBorders();
            TopBorder topBorder17 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder17 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder16 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder17 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders14.Append(topBorder17);
            tableCellBorders14.Append(leftBorder17);
            tableCellBorders14.Append(bottomBorder16);
            tableCellBorders14.Append(rightBorder17);
            Shading shading14 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties14.Append(tableCellWidth14);
            tableCellProperties14.Append(gridSpan9);
            tableCellProperties14.Append(tableCellBorders14);
            tableCellProperties14.Append(shading14);

            Paragraph paragraph25 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "00284D35", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D35" };

            ParagraphProperties paragraphProperties25 = new ParagraphProperties();
            Justification justification23 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties10 = new ParagraphMarkRunProperties();
            FontSize fontSize19 = new FontSize() { Val = "14" };
            FontSizeComplexScript fontSizeComplexScript19 = new FontSizeComplexScript() { Val = "14" };

            paragraphMarkRunProperties10.Append(fontSize19);
            paragraphMarkRunProperties10.Append(fontSizeComplexScript19);

            paragraphProperties25.Append(justification23);
            paragraphProperties25.Append(paragraphMarkRunProperties10);

            Run run22 = new Run() { RsidRunProperties = "00E96696" };

            RunProperties runProperties12 = new RunProperties();
            FontSize fontSize20 = new FontSize() { Val = "14" };
            FontSizeComplexScript fontSizeComplexScript20 = new FontSizeComplexScript() { Val = "14" };

            runProperties12.Append(fontSize20);
            runProperties12.Append(fontSizeComplexScript20);
            Text text22 = new Text();
            text22.Text = "(месяц, год,номер приказа)";

            run22.Append(runProperties12);
            run22.Append(text22);

            paragraph25.Append(paragraphProperties25);
            paragraph25.Append(run22);

            tableCell14.Append(tableCellProperties14);
            tableCell14.Append(paragraph25);

            tableRow3.Append(tableRowProperties1);
            tableRow3.Append(tableCell8);
            tableRow3.Append(tableCell9);
            tableRow3.Append(tableCell10);
            tableRow3.Append(tableCell11);
            tableRow3.Append(tableCell12);
            tableRow3.Append(tableCell13);
            tableRow3.Append(tableCell14);

            TableRow tableRow4 = new TableRow() { RsidTableRowAddition = "00284D35", RsidTableRowProperties = "00E96696" };

            TableCell tableCell15 = new TableCell();

            TableCellProperties tableCellProperties15 = new TableCellProperties();
            TableCellWidth tableCellWidth15 = new TableCellWidth() { Width = "1908", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan10 = new GridSpan() { Val = 5 };

            TableCellBorders tableCellBorders15 = new TableCellBorders();
            TopBorder topBorder18 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder18 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder17 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder18 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders15.Append(topBorder18);
            tableCellBorders15.Append(leftBorder18);
            tableCellBorders15.Append(bottomBorder17);
            tableCellBorders15.Append(rightBorder18);
            Shading shading15 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties15.Append(tableCellWidth15);
            tableCellProperties15.Append(gridSpan10);
            tableCellProperties15.Append(tableCellBorders15);
            tableCellProperties15.Append(shading15);

            Paragraph paragraph26 = new Paragraph() { RsidParagraphAddition = "00284D35", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D35" };

            ParagraphProperties paragraphProperties26 = new ParagraphProperties();
            Justification justification24 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties26.Append(justification24);

            Run run23 = new Run();
            Text text23 = new Text();
            text23.Text = "Дата рождения";

            run23.Append(text23);

            paragraph26.Append(paragraphProperties26);
            paragraph26.Append(run23);

            tableCell15.Append(tableCellProperties15);
            tableCell15.Append(paragraph26);

            TableCell tableCell16 = new TableCell();

            TableCellProperties tableCellProperties16 = new TableCellProperties();
            TableCellWidth tableCellWidth16 = new TableCellWidth() { Width = "5255", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan11 = new GridSpan() { Val = 10 };

            TableCellBorders tableCellBorders16 = new TableCellBorders();
            TopBorder topBorder19 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder19 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder18 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder19 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders16.Append(topBorder19);
            tableCellBorders16.Append(leftBorder19);
            tableCellBorders16.Append(bottomBorder18);
            tableCellBorders16.Append(rightBorder19);
            Shading shading16 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties16.Append(tableCellWidth16);
            tableCellProperties16.Append(gridSpan11);
            tableCellProperties16.Append(tableCellBorders16);
            tableCellProperties16.Append(shading16);

            Paragraph paragraph27 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "00284D35", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00DB2712" };

            ParagraphProperties paragraphProperties27 = new ParagraphProperties();
            Justification justification25 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties11 = new ParagraphMarkRunProperties();
            Italic italic14 = new Italic();
            FontSize fontSize21 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript21 = new FontSizeComplexScript() { Val = "26" };
            Languages languages13 = new Languages() { Val = "en-US" };

            paragraphMarkRunProperties11.Append(italic14);
            paragraphMarkRunProperties11.Append(fontSize21);
            paragraphMarkRunProperties11.Append(fontSizeComplexScript21);
            paragraphMarkRunProperties11.Append(languages13);

            paragraphProperties27.Append(justification25);
            paragraphProperties27.Append(paragraphMarkRunProperties11);

            Run run24 = new Run() { RsidRunProperties = "00E96696" };

            RunProperties runProperties13 = new RunProperties();
            Italic italic15 = new Italic();
            FontSize fontSize22 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript22 = new FontSizeComplexScript() { Val = "26" };
            Languages languages14 = new Languages() { Val = "en-US" };

            runProperties13.Append(italic15);
            runProperties13.Append(fontSize22);
            runProperties13.Append(fontSizeComplexScript22);
            runProperties13.Append(languages14);
            Text text24 = new Text();
            text24.Text = "#birthday";

            run24.Append(runProperties13);
            run24.Append(text24);

            paragraph27.Append(paragraphProperties27);
            paragraph27.Append(run24);

            tableCell16.Append(tableCellProperties16);
            tableCell16.Append(paragraph27);

            TableCell tableCell17 = new TableCell();

            TableCellProperties tableCellProperties17 = new TableCellProperties();
            TableCellWidth tableCellWidth17 = new TableCellWidth() { Width = "505", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders17 = new TableCellBorders();
            TopBorder topBorder20 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder20 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder19 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder20 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders17.Append(topBorder20);
            tableCellBorders17.Append(leftBorder20);
            tableCellBorders17.Append(bottomBorder19);
            tableCellBorders17.Append(rightBorder20);
            Shading shading17 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties17.Append(tableCellWidth17);
            tableCellProperties17.Append(tableCellBorders17);
            tableCellProperties17.Append(shading17);

            Paragraph paragraph28 = new Paragraph() { RsidParagraphAddition = "00284D35", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D35" };

            ParagraphProperties paragraphProperties28 = new ParagraphProperties();
            Justification justification26 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties28.Append(justification26);

            paragraph28.Append(paragraphProperties28);

            tableCell17.Append(tableCellProperties17);
            tableCell17.Append(paragraph28);

            TableCell tableCell18 = new TableCell();

            TableCellProperties tableCellProperties18 = new TableCellProperties();
            TableCellWidth tableCellWidth18 = new TableCellWidth() { Width = "4499", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan12 = new GridSpan() { Val = 7 };

            TableCellBorders tableCellBorders18 = new TableCellBorders();
            TopBorder topBorder21 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder21 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder20 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder21 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders18.Append(topBorder21);
            tableCellBorders18.Append(leftBorder21);
            tableCellBorders18.Append(bottomBorder20);
            tableCellBorders18.Append(rightBorder21);
            Shading shading18 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties18.Append(tableCellWidth18);
            tableCellProperties18.Append(gridSpan12);
            tableCellProperties18.Append(tableCellBorders18);
            tableCellProperties18.Append(shading18);

            Paragraph paragraph29 = new Paragraph() { RsidParagraphMarkRevision = "004C4782", RsidParagraphAddition = "00284D35", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "004C4782" };

            ParagraphProperties paragraphProperties29 = new ParagraphProperties();
            Indentation indentation11 = new Indentation() { Left = "-108", Right = "-108" };
            Justification justification27 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties29.Append(indentation11);
            paragraphProperties29.Append(justification27);

            Run run25 = new Run() { RsidRunProperties = "004C4782" };
            Text text25 = new Text();
            text25.Text = "Окончание обучения на военной кафедре:";

            run25.Append(text25);

            paragraph29.Append(paragraphProperties29);
            paragraph29.Append(run25);

            tableCell18.Append(tableCellProperties18);
            tableCell18.Append(paragraph29);

            TableCell tableCell19 = new TableCell();

            TableCellProperties tableCellProperties19 = new TableCellProperties();
            TableCellWidth tableCellWidth19 = new TableCellWidth() { Width = "1981", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders19 = new TableCellBorders();
            TopBorder topBorder22 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder22 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder21 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder22 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders19.Append(topBorder22);
            tableCellBorders19.Append(leftBorder22);
            tableCellBorders19.Append(bottomBorder21);
            tableCellBorders19.Append(rightBorder22);
            Shading shading19 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties19.Append(tableCellWidth19);
            tableCellProperties19.Append(tableCellBorders19);
            tableCellProperties19.Append(shading19);

            Paragraph paragraph30 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "00284D35", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00DB2712" };

            ParagraphProperties paragraphProperties30 = new ParagraphProperties();
            Justification justification28 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties12 = new ParagraphMarkRunProperties();
            Italic italic16 = new Italic();
            FontSize fontSize23 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript23 = new FontSizeComplexScript() { Val = "26" };
            Languages languages15 = new Languages() { Val = "en-US" };

            paragraphMarkRunProperties12.Append(italic16);
            paragraphMarkRunProperties12.Append(fontSize23);
            paragraphMarkRunProperties12.Append(fontSizeComplexScript23);
            paragraphMarkRunProperties12.Append(languages15);

            paragraphProperties30.Append(justification28);
            paragraphProperties30.Append(paragraphMarkRunProperties12);

            Run run26 = new Run() { RsidRunProperties = "00E96696" };

            RunProperties runProperties14 = new RunProperties();
            Italic italic17 = new Italic();
            FontSize fontSize24 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript24 = new FontSizeComplexScript() { Val = "26" };
            Languages languages16 = new Languages() { Val = "en-US" };

            runProperties14.Append(italic17);
            runProperties14.Append(fontSize24);
            runProperties14.Append(fontSizeComplexScript24);
            runProperties14.Append(languages16);
            Text text26 = new Text();
            text26.Text = "#wk_end";

            run26.Append(runProperties14);
            run26.Append(text26);

            paragraph30.Append(paragraphProperties30);
            paragraph30.Append(run26);

            tableCell19.Append(tableCellProperties19);
            tableCell19.Append(paragraph30);

            tableRow4.Append(tableCell15);
            tableRow4.Append(tableCell16);
            tableRow4.Append(tableCell17);
            tableRow4.Append(tableCell18);
            tableRow4.Append(tableCell19);

            TableRow tableRow5 = new TableRow() { RsidTableRowAddition = "004C4782", RsidTableRowProperties = "001A3DA5" };

            TableCell tableCell20 = new TableCell();

            TableCellProperties tableCellProperties20 = new TableCellProperties();
            TableCellWidth tableCellWidth20 = new TableCellWidth() { Width = "2088", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan13 = new GridSpan() { Val = 6 };

            TableCellBorders tableCellBorders20 = new TableCellBorders();
            TopBorder topBorder23 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder23 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder22 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder23 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders20.Append(topBorder23);
            tableCellBorders20.Append(leftBorder23);
            tableCellBorders20.Append(bottomBorder22);
            tableCellBorders20.Append(rightBorder23);
            Shading shading20 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties20.Append(tableCellWidth20);
            tableCellProperties20.Append(gridSpan13);
            tableCellProperties20.Append(tableCellBorders20);
            tableCellProperties20.Append(shading20);

            Paragraph paragraph31 = new Paragraph() { RsidParagraphAddition = "004C4782", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "004C4782" };

            ParagraphProperties paragraphProperties31 = new ParagraphProperties();
            Justification justification29 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties31.Append(justification29);

            Run run27 = new Run();
            Text text27 = new Text();
            text27.Text = "Место рождения";

            run27.Append(text27);

            paragraph31.Append(paragraphProperties31);
            paragraph31.Append(run27);

            tableCell20.Append(tableCellProperties20);
            tableCell20.Append(paragraph31);

            TableCell tableCell21 = new TableCell();

            TableCellProperties tableCellProperties21 = new TableCellProperties();
            TableCellWidth tableCellWidth21 = new TableCellWidth() { Width = "5075", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan14 = new GridSpan() { Val = 9 };

            TableCellBorders tableCellBorders21 = new TableCellBorders();
            TopBorder topBorder24 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder24 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder23 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder24 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders21.Append(topBorder24);
            tableCellBorders21.Append(leftBorder24);
            tableCellBorders21.Append(bottomBorder23);
            tableCellBorders21.Append(rightBorder24);
            Shading shading21 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties21.Append(tableCellWidth21);
            tableCellProperties21.Append(gridSpan14);
            tableCellProperties21.Append(tableCellBorders21);
            tableCellProperties21.Append(shading21);

            Paragraph paragraph32 = new Paragraph() { RsidParagraphMarkRevision = "001A3DA5", RsidParagraphAddition = "004C4782", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00644EAD" };

            ParagraphProperties paragraphProperties32 = new ParagraphProperties();
            Justification justification30 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties13 = new ParagraphMarkRunProperties();
            Italic italic18 = new Italic();
            FontSize fontSize25 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript25 = new FontSizeComplexScript() { Val = "26" };

            paragraphMarkRunProperties13.Append(italic18);
            paragraphMarkRunProperties13.Append(fontSize25);
            paragraphMarkRunProperties13.Append(fontSizeComplexScript25);

            paragraphProperties32.Append(justification30);
            paragraphProperties32.Append(paragraphMarkRunProperties13);

            Run run28 = new Run() { RsidRunProperties = "00644EAD" };

            RunProperties runProperties15 = new RunProperties();
            Italic italic19 = new Italic();
            FontSize fontSize26 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript26 = new FontSizeComplexScript() { Val = "26" };
            Languages languages17 = new Languages() { Val = "en-US" };

            runProperties15.Append(italic19);
            runProperties15.Append(fontSize26);
            runProperties15.Append(fontSizeComplexScript26);
            runProperties15.Append(languages17);
            Text text28 = new Text();
            text28.Text = "#bplace";

            run28.Append(runProperties15);
            run28.Append(text28);

            paragraph32.Append(paragraphProperties32);
            paragraph32.Append(run28);

            tableCell21.Append(tableCellProperties21);
            tableCell21.Append(paragraph32);

            TableCell tableCell22 = new TableCell();

            TableCellProperties tableCellProperties22 = new TableCellProperties();
            TableCellWidth tableCellWidth22 = new TableCellWidth() { Width = "505", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders22 = new TableCellBorders();
            TopBorder topBorder25 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder25 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder24 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder25 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders22.Append(topBorder25);
            tableCellBorders22.Append(leftBorder25);
            tableCellBorders22.Append(bottomBorder24);
            tableCellBorders22.Append(rightBorder25);
            Shading shading22 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties22.Append(tableCellWidth22);
            tableCellProperties22.Append(tableCellBorders22);
            tableCellProperties22.Append(shading22);

            Paragraph paragraph33 = new Paragraph() { RsidParagraphAddition = "004C4782", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "004C4782" };

            ParagraphProperties paragraphProperties33 = new ParagraphProperties();
            Justification justification31 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties33.Append(justification31);

            paragraph33.Append(paragraphProperties33);

            tableCell22.Append(tableCellProperties22);
            tableCell22.Append(paragraph33);

            TableCell tableCell23 = new TableCell();

            TableCellProperties tableCellProperties23 = new TableCellProperties();
            TableCellWidth tableCellWidth23 = new TableCellWidth() { Width = "3060", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan15 = new GridSpan() { Val = 3 };

            TableCellBorders tableCellBorders23 = new TableCellBorders();
            TopBorder topBorder26 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder26 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder25 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder26 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders23.Append(topBorder26);
            tableCellBorders23.Append(leftBorder26);
            tableCellBorders23.Append(bottomBorder25);
            tableCellBorders23.Append(rightBorder26);
            Shading shading23 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties23.Append(tableCellWidth23);
            tableCellProperties23.Append(gridSpan15);
            tableCellProperties23.Append(tableCellBorders23);
            tableCellProperties23.Append(shading23);

            Paragraph paragraph34 = new Paragraph() { RsidParagraphAddition = "004C4782", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "004C4782" };

            ParagraphProperties paragraphProperties34 = new ParagraphProperties();
            Justification justification32 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties34.Append(justification32);

            paragraph34.Append(paragraphProperties34);

            tableCell23.Append(tableCellProperties23);
            tableCell23.Append(paragraph34);

            TableCell tableCell24 = new TableCell();

            TableCellProperties tableCellProperties24 = new TableCellProperties();
            TableCellWidth tableCellWidth24 = new TableCellWidth() { Width = "3420", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan16 = new GridSpan() { Val = 5 };

            TableCellBorders tableCellBorders24 = new TableCellBorders();
            TopBorder topBorder27 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder27 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder26 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder27 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders24.Append(topBorder27);
            tableCellBorders24.Append(leftBorder27);
            tableCellBorders24.Append(bottomBorder26);
            tableCellBorders24.Append(rightBorder27);
            Shading shading24 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties24.Append(tableCellWidth24);
            tableCellProperties24.Append(gridSpan16);
            tableCellProperties24.Append(tableCellBorders24);
            tableCellProperties24.Append(shading24);

            Paragraph paragraph35 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "004C4782", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "004C4782" };

            ParagraphProperties paragraphProperties35 = new ParagraphProperties();
            Justification justification33 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties14 = new ParagraphMarkRunProperties();
            FontSize fontSize27 = new FontSize() { Val = "14" };
            FontSizeComplexScript fontSizeComplexScript27 = new FontSizeComplexScript() { Val = "14" };

            paragraphMarkRunProperties14.Append(fontSize27);
            paragraphMarkRunProperties14.Append(fontSizeComplexScript27);

            paragraphProperties35.Append(justification33);
            paragraphProperties35.Append(paragraphMarkRunProperties14);

            Run run29 = new Run() { RsidRunProperties = "00E96696" };

            RunProperties runProperties16 = new RunProperties();
            FontSize fontSize28 = new FontSize() { Val = "14" };
            FontSizeComplexScript fontSizeComplexScript28 = new FontSizeComplexScript() { Val = "14" };

            runProperties16.Append(fontSize28);
            runProperties16.Append(fontSizeComplexScript28);
            Text text29 = new Text();
            text29.Text = "(месяц, год)";

            run29.Append(runProperties16);
            run29.Append(text29);

            paragraph35.Append(paragraphProperties35);
            paragraph35.Append(run29);

            tableCell24.Append(tableCellProperties24);
            tableCell24.Append(paragraph35);

            tableRow5.Append(tableCell20);
            tableRow5.Append(tableCell21);
            tableRow5.Append(tableCell22);
            tableRow5.Append(tableCell23);
            tableRow5.Append(tableCell24);

            TableRow tableRow6 = new TableRow() { RsidTableRowAddition = "000A7E3D", RsidTableRowProperties = "00E96696" };

            TableCell tableCell25 = new TableCell();

            TableCellProperties tableCellProperties25 = new TableCellProperties();
            TableCellWidth tableCellWidth25 = new TableCellWidth() { Width = "7163", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan17 = new GridSpan() { Val = 15 };

            TableCellBorders tableCellBorders25 = new TableCellBorders();
            TopBorder topBorder28 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder28 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder27 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder28 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders25.Append(topBorder28);
            tableCellBorders25.Append(leftBorder28);
            tableCellBorders25.Append(bottomBorder27);
            tableCellBorders25.Append(rightBorder28);
            Shading shading25 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties25.Append(tableCellWidth25);
            tableCellProperties25.Append(gridSpan17);
            tableCellProperties25.Append(tableCellBorders25);
            tableCellProperties25.Append(shading25);

            Paragraph paragraph36 = new Paragraph() { RsidParagraphAddition = "000A7E3D", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "000A7E3D" };

            ParagraphProperties paragraphProperties36 = new ParagraphProperties();
            Justification justification34 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties36.Append(justification34);

            Run run30 = new Run();
            Text text30 = new Text();
            text30.Text = "Учебные взвода по годам обучения:";

            run30.Append(text30);

            paragraph36.Append(paragraphProperties36);
            paragraph36.Append(run30);

            tableCell25.Append(tableCellProperties25);
            tableCell25.Append(paragraph36);

            TableCell tableCell26 = new TableCell();

            TableCellProperties tableCellProperties26 = new TableCellProperties();
            TableCellWidth tableCellWidth26 = new TableCellWidth() { Width = "505", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders26 = new TableCellBorders();
            TopBorder topBorder29 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder29 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder28 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder29 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders26.Append(topBorder29);
            tableCellBorders26.Append(leftBorder29);
            tableCellBorders26.Append(bottomBorder28);
            tableCellBorders26.Append(rightBorder29);
            Shading shading26 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties26.Append(tableCellWidth26);
            tableCellProperties26.Append(tableCellBorders26);
            tableCellProperties26.Append(shading26);

            Paragraph paragraph37 = new Paragraph() { RsidParagraphAddition = "000A7E3D", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "000A7E3D" };

            ParagraphProperties paragraphProperties37 = new ParagraphProperties();
            Justification justification35 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties37.Append(justification35);

            paragraph37.Append(paragraphProperties37);

            tableCell26.Append(tableCellProperties26);
            tableCell26.Append(paragraph37);

            TableCell tableCell27 = new TableCell();

            TableCellProperties tableCellProperties27 = new TableCellProperties();
            TableCellWidth tableCellWidth27 = new TableCellWidth() { Width = "2520", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders27 = new TableCellBorders();
            TopBorder topBorder30 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder30 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder29 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder30 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders27.Append(topBorder30);
            tableCellBorders27.Append(leftBorder30);
            tableCellBorders27.Append(bottomBorder29);
            tableCellBorders27.Append(rightBorder30);
            Shading shading27 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties27.Append(tableCellWidth27);
            tableCellProperties27.Append(tableCellBorders27);
            tableCellProperties27.Append(shading27);

            Paragraph paragraph38 = new Paragraph() { RsidParagraphAddition = "000A7E3D", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "000A7E3D" };

            ParagraphProperties paragraphProperties38 = new ParagraphProperties();
            Indentation indentation12 = new Indentation() { Left = "-108" };

            paragraphProperties38.Append(indentation12);

            Run run31 = new Run();
            Text text31 = new Text();
            text31.Text = "номер и дата приказа";

            run31.Append(text31);

            paragraph38.Append(paragraphProperties38);
            paragraph38.Append(run31);

            tableCell27.Append(tableCellProperties27);
            tableCell27.Append(paragraph38);

            TableCell tableCell28 = new TableCell();

            TableCellProperties tableCellProperties28 = new TableCellProperties();
            TableCellWidth tableCellWidth28 = new TableCellWidth() { Width = "3960", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan18 = new GridSpan() { Val = 7 };

            TableCellBorders tableCellBorders28 = new TableCellBorders();
            TopBorder topBorder31 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder31 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder30 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder31 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders28.Append(topBorder31);
            tableCellBorders28.Append(leftBorder31);
            tableCellBorders28.Append(bottomBorder30);
            tableCellBorders28.Append(rightBorder31);
            Shading shading28 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties28.Append(tableCellWidth28);
            tableCellProperties28.Append(gridSpan18);
            tableCellProperties28.Append(tableCellBorders28);
            tableCellProperties28.Append(shading28);

            Paragraph paragraph39 = new Paragraph() { RsidParagraphAddition = "000A7E3D", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "000A7E3D" };

            ParagraphProperties paragraphProperties39 = new ParagraphProperties();
            Justification justification36 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties39.Append(justification36);

            paragraph39.Append(paragraphProperties39);

            tableCell28.Append(tableCellProperties28);
            tableCell28.Append(paragraph39);

            tableRow6.Append(tableCell25);
            tableRow6.Append(tableCell26);
            tableRow6.Append(tableCell27);
            tableRow6.Append(tableCell28);

            TableRow tableRow7 = new TableRow() { RsidTableRowAddition = "000A7E3D", RsidTableRowProperties = "00E96696" };

            TableCell tableCell29 = new TableCell();

            TableCellProperties tableCellProperties29 = new TableCellProperties();
            TableCellWidth tableCellWidth29 = new TableCellWidth() { Width = "1548", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan19 = new GridSpan() { Val = 4 };

            TableCellBorders tableCellBorders29 = new TableCellBorders();
            TopBorder topBorder32 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder32 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder31 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder32 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders29.Append(topBorder32);
            tableCellBorders29.Append(leftBorder32);
            tableCellBorders29.Append(bottomBorder31);
            tableCellBorders29.Append(rightBorder32);
            Shading shading29 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties29.Append(tableCellWidth29);
            tableCellProperties29.Append(gridSpan19);
            tableCellProperties29.Append(tableCellBorders29);
            tableCellProperties29.Append(shading29);

            Paragraph paragraph40 = new Paragraph() { RsidParagraphAddition = "000A7E3D", RsidParagraphProperties = "00C96451", RsidRunAdditionDefault = "000A7E3D" };

            ParagraphProperties paragraphProperties40 = new ParagraphProperties();
            Justification justification37 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties40.Append(justification37);

            Run run32 = new Run();
            Text text32 = new Text();
            text32.Text = "Факультет";

            run32.Append(text32);

            paragraph40.Append(paragraphProperties40);
            paragraph40.Append(run32);

            tableCell29.Append(tableCellProperties29);
            tableCell29.Append(paragraph40);

            TableCell tableCell30 = new TableCell();

            TableCellProperties tableCellProperties30 = new TableCellProperties();
            TableCellWidth tableCellWidth30 = new TableCellWidth() { Width = "540", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan20 = new GridSpan() { Val = 2 };

            TableCellBorders tableCellBorders30 = new TableCellBorders();
            TopBorder topBorder33 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder33 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder32 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder33 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders30.Append(topBorder33);
            tableCellBorders30.Append(leftBorder33);
            tableCellBorders30.Append(bottomBorder32);
            tableCellBorders30.Append(rightBorder33);
            Shading shading30 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties30.Append(tableCellWidth30);
            tableCellProperties30.Append(gridSpan20);
            tableCellProperties30.Append(tableCellBorders30);
            tableCellProperties30.Append(shading30);

            Paragraph paragraph41 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "000A7E3D", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00C96451" };

            ParagraphProperties paragraphProperties41 = new ParagraphProperties();
            Justification justification38 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties15 = new ParagraphMarkRunProperties();
            Italic italic20 = new Italic();
            FontSize fontSize29 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript29 = new FontSizeComplexScript() { Val = "28" };
            Languages languages18 = new Languages() { Val = "en-US" };

            paragraphMarkRunProperties15.Append(italic20);
            paragraphMarkRunProperties15.Append(fontSize29);
            paragraphMarkRunProperties15.Append(fontSizeComplexScript29);
            paragraphMarkRunProperties15.Append(languages18);

            paragraphProperties41.Append(justification38);
            paragraphProperties41.Append(paragraphMarkRunProperties15);

            Run run33 = new Run();

            RunProperties runProperties17 = new RunProperties();
            Italic italic21 = new Italic();
            FontSize fontSize30 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript30 = new FontSizeComplexScript() { Val = "28" };
            Languages languages19 = new Languages() { Val = "en-US" };

            runProperties17.Append(italic21);
            runProperties17.Append(fontSize30);
            runProperties17.Append(fontSizeComplexScript30);
            runProperties17.Append(languages19);
            Text text33 = new Text();
            text33.Text = "#z";

            run33.Append(runProperties17);
            run33.Append(text33);

            paragraph41.Append(paragraphProperties41);
            paragraph41.Append(run33);

            tableCell30.Append(tableCellProperties30);
            tableCell30.Append(paragraph41);

            TableCell tableCell31 = new TableCell();

            TableCellProperties tableCellProperties31 = new TableCellProperties();
            TableCellWidth tableCellWidth31 = new TableCellWidth() { Width = "1980", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan21 = new GridSpan() { Val = 5 };

            TableCellBorders tableCellBorders31 = new TableCellBorders();
            TopBorder topBorder34 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder34 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder33 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder34 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders31.Append(topBorder34);
            tableCellBorders31.Append(leftBorder34);
            tableCellBorders31.Append(bottomBorder33);
            tableCellBorders31.Append(rightBorder34);
            Shading shading31 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties31.Append(tableCellWidth31);
            tableCellProperties31.Append(gridSpan21);
            tableCellProperties31.Append(tableCellBorders31);
            tableCellProperties31.Append(shading31);

            Paragraph paragraph42 = new Paragraph() { RsidParagraphMarkRevision = "00F40B18", RsidParagraphAddition = "000A7E3D", RsidParagraphProperties = "00F40B18", RsidRunAdditionDefault = "00C96451" };

            Run run34 = new Run();

            RunProperties runProperties18 = new RunProperties();
            Languages languages20 = new Languages() { Val = "en-US" };

            runProperties18.Append(languages20);
            Text text34 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text34.Text = " ";

            run34.Append(runProperties18);
            run34.Append(text34);

            Run run35 = new Run() { RsidRunAddition = "000A7E3D" };
            Text text35 = new Text();
            text35.Text = ",учебная группа";

            run35.Append(text35);

            paragraph42.Append(run34);
            paragraph42.Append(run35);

            tableCell31.Append(tableCellProperties31);
            tableCell31.Append(paragraph42);

            TableCell tableCell32 = new TableCell();

            TableCellProperties tableCellProperties32 = new TableCellProperties();
            TableCellWidth tableCellWidth32 = new TableCellWidth() { Width = "3095", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan22 = new GridSpan() { Val = 4 };

            TableCellBorders tableCellBorders32 = new TableCellBorders();
            TopBorder topBorder35 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder35 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder34 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder35 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders32.Append(topBorder35);
            tableCellBorders32.Append(leftBorder35);
            tableCellBorders32.Append(bottomBorder34);
            tableCellBorders32.Append(rightBorder35);
            Shading shading32 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties32.Append(tableCellWidth32);
            tableCellProperties32.Append(gridSpan22);
            tableCellProperties32.Append(tableCellBorders32);
            tableCellProperties32.Append(shading32);

            Paragraph paragraph43 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "000A7E3D", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "0056326A" };

            ParagraphProperties paragraphProperties42 = new ParagraphProperties();
            Justification justification39 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties16 = new ParagraphMarkRunProperties();
            Italic italic22 = new Italic();
            FontSize fontSize31 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript31 = new FontSizeComplexScript() { Val = "26" };
            Languages languages21 = new Languages() { Val = "en-US" };

            paragraphMarkRunProperties16.Append(italic22);
            paragraphMarkRunProperties16.Append(fontSize31);
            paragraphMarkRunProperties16.Append(fontSizeComplexScript31);
            paragraphMarkRunProperties16.Append(languages21);

            paragraphProperties42.Append(justification39);
            paragraphProperties42.Append(paragraphMarkRunProperties16);

            Run run36 = new Run();

            RunProperties runProperties19 = new RunProperties();
            Italic italic23 = new Italic();
            FontSize fontSize32 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript32 = new FontSizeComplexScript() { Val = "26" };
            Languages languages22 = new Languages() { Val = "en-US" };

            runProperties19.Append(italic23);
            runProperties19.Append(fontSize32);
            runProperties19.Append(fontSizeComplexScript32);
            runProperties19.Append(languages22);
            Text text36 = new Text();
            text36.Text = "#g";

            run36.Append(runProperties19);
            run36.Append(text36);

            Run run37 = new Run() { RsidRunProperties = "00E96696", RsidRunAddition = "000A7E3D" };

            RunProperties runProperties20 = new RunProperties();
            Italic italic24 = new Italic();
            FontSize fontSize33 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript33 = new FontSizeComplexScript() { Val = "26" };
            Languages languages23 = new Languages() { Val = "en-US" };

            runProperties20.Append(italic24);
            runProperties20.Append(fontSize33);
            runProperties20.Append(fontSizeComplexScript33);
            runProperties20.Append(languages23);
            Text text37 = new Text();
            text37.Text = "p";

            run37.Append(runProperties20);
            run37.Append(text37);

            paragraph43.Append(paragraphProperties42);
            paragraph43.Append(run36);
            paragraph43.Append(run37);

            tableCell32.Append(tableCellProperties32);
            tableCell32.Append(paragraph43);

            TableCell tableCell33 = new TableCell();

            TableCellProperties tableCellProperties33 = new TableCellProperties();
            TableCellWidth tableCellWidth33 = new TableCellWidth() { Width = "505", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders33 = new TableCellBorders();
            TopBorder topBorder36 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder36 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder35 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder36 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders33.Append(topBorder36);
            tableCellBorders33.Append(leftBorder36);
            tableCellBorders33.Append(bottomBorder35);
            tableCellBorders33.Append(rightBorder36);
            Shading shading33 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties33.Append(tableCellWidth33);
            tableCellProperties33.Append(tableCellBorders33);
            tableCellProperties33.Append(shading33);

            Paragraph paragraph44 = new Paragraph() { RsidParagraphAddition = "000A7E3D", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "000A7E3D" };

            ParagraphProperties paragraphProperties43 = new ParagraphProperties();
            Justification justification40 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties43.Append(justification40);

            paragraph44.Append(paragraphProperties43);

            tableCell33.Append(tableCellProperties33);
            tableCell33.Append(paragraph44);

            TableCell tableCell34 = new TableCell();

            TableCellProperties tableCellProperties34 = new TableCellProperties();
            TableCellWidth tableCellWidth34 = new TableCellWidth() { Width = "3851", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan23 = new GridSpan() { Val = 5 };

            TableCellBorders tableCellBorders34 = new TableCellBorders();
            TopBorder topBorder37 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder37 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder36 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder37 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders34.Append(topBorder37);
            tableCellBorders34.Append(leftBorder37);
            tableCellBorders34.Append(bottomBorder36);
            tableCellBorders34.Append(rightBorder37);
            Shading shading34 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties34.Append(tableCellWidth34);
            tableCellProperties34.Append(gridSpan23);
            tableCellProperties34.Append(tableCellBorders34);
            tableCellProperties34.Append(shading34);

            Paragraph paragraph45 = new Paragraph() { RsidParagraphMarkRevision = "004C4782", RsidParagraphAddition = "000A7E3D", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "000A7E3D" };

            ParagraphProperties paragraphProperties44 = new ParagraphProperties();
            Indentation indentation13 = new Indentation() { Left = "-108", Right = "-52" };

            paragraphProperties44.Append(indentation13);

            Run run38 = new Run() { RsidRunProperties = "004C4782" };
            Text text38 = new Text();
            text38.Text = "Адрес места жительства родителей";

            run38.Append(text38);

            paragraph45.Append(paragraphProperties44);
            paragraph45.Append(run38);

            tableCell34.Append(tableCellProperties34);
            tableCell34.Append(paragraph45);

            TableCell tableCell35 = new TableCell();

            TableCellProperties tableCellProperties35 = new TableCellProperties();
            TableCellWidth tableCellWidth35 = new TableCellWidth() { Width = "2629", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan24 = new GridSpan() { Val = 3 };

            TableCellBorders tableCellBorders35 = new TableCellBorders();
            TopBorder topBorder38 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder38 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder37 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder38 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders35.Append(topBorder38);
            tableCellBorders35.Append(leftBorder38);
            tableCellBorders35.Append(bottomBorder37);
            tableCellBorders35.Append(rightBorder38);
            Shading shading35 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties35.Append(tableCellWidth35);
            tableCellProperties35.Append(gridSpan24);
            tableCellProperties35.Append(tableCellBorders35);
            tableCellProperties35.Append(shading35);

            Paragraph paragraph46 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "000A7E3D", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "000A7E3D" };

            ParagraphProperties paragraphProperties45 = new ParagraphProperties();
            Justification justification41 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties17 = new ParagraphMarkRunProperties();
            Italic italic25 = new Italic();
            FontSize fontSize34 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript34 = new FontSizeComplexScript() { Val = "26" };

            paragraphMarkRunProperties17.Append(italic25);
            paragraphMarkRunProperties17.Append(fontSize34);
            paragraphMarkRunProperties17.Append(fontSizeComplexScript34);

            paragraphProperties45.Append(justification41);
            paragraphProperties45.Append(paragraphMarkRunProperties17);

            Run run39 = new Run() { RsidRunProperties = "00E96696" };

            RunProperties runProperties21 = new RunProperties();
            Italic italic26 = new Italic();
            FontSize fontSize35 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript35 = new FontSizeComplexScript() { Val = "26" };
            Languages languages24 = new Languages() { Val = "en-US" };

            runProperties21.Append(italic26);
            runProperties21.Append(fontSize35);
            runProperties21.Append(fontSizeComplexScript35);
            runProperties21.Append(languages24);
            Text text39 = new Text();
            text39.Text = "#parents1";

            run39.Append(runProperties21);
            run39.Append(text39);

            paragraph46.Append(paragraphProperties45);
            paragraph46.Append(run39);

            tableCell35.Append(tableCellProperties35);
            tableCell35.Append(paragraph46);

            tableRow7.Append(tableCell29);
            tableRow7.Append(tableCell30);
            tableRow7.Append(tableCell31);
            tableRow7.Append(tableCell32);
            tableRow7.Append(tableCell33);
            tableRow7.Append(tableCell34);
            tableRow7.Append(tableCell35);

            TableRow tableRow8 = new TableRow() { RsidTableRowAddition = "000A7E3D", RsidTableRowProperties = "00E96696" };

            TableCell tableCell36 = new TableCell();

            TableCellProperties tableCellProperties36 = new TableCellProperties();
            TableCellWidth tableCellWidth36 = new TableCellWidth() { Width = "1152", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan25 = new GridSpan() { Val = 2 };

            TableCellBorders tableCellBorders36 = new TableCellBorders();
            TopBorder topBorder39 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder39 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder38 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder39 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders36.Append(topBorder39);
            tableCellBorders36.Append(leftBorder39);
            tableCellBorders36.Append(bottomBorder38);
            tableCellBorders36.Append(rightBorder39);
            Shading shading36 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties36.Append(tableCellWidth36);
            tableCellProperties36.Append(gridSpan25);
            tableCellProperties36.Append(tableCellBorders36);
            tableCellProperties36.Append(shading36);

            Paragraph paragraph47 = new Paragraph() { RsidParagraphAddition = "000A7E3D", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "000A7E3D" };

            ParagraphProperties paragraphProperties46 = new ParagraphProperties();
            Justification justification42 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties46.Append(justification42);

            Run run40 = new Run();
            Text text40 = new Text();
            text40.Text = "2-й курс";

            run40.Append(text40);

            paragraph47.Append(paragraphProperties46);
            paragraph47.Append(run40);

            tableCell36.Append(tableCellProperties36);
            tableCell36.Append(paragraph47);

            TableCell tableCell37 = new TableCell();

            TableCellProperties tableCellProperties37 = new TableCellProperties();
            TableCellWidth tableCellWidth37 = new TableCellWidth() { Width = "2376", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan26 = new GridSpan() { Val = 7 };

            TableCellBorders tableCellBorders37 = new TableCellBorders();
            TopBorder topBorder40 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder40 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder39 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder40 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders37.Append(topBorder40);
            tableCellBorders37.Append(leftBorder40);
            tableCellBorders37.Append(bottomBorder39);
            tableCellBorders37.Append(rightBorder40);
            Shading shading37 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties37.Append(tableCellWidth37);
            tableCellProperties37.Append(gridSpan26);
            tableCellProperties37.Append(tableCellBorders37);
            tableCellProperties37.Append(shading37);

            Paragraph paragraph48 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "000A7E3D", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "000A7E3D" };

            ParagraphProperties paragraphProperties47 = new ParagraphProperties();
            Justification justification43 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties18 = new ParagraphMarkRunProperties();
            Italic italic27 = new Italic();
            FontSize fontSize36 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript36 = new FontSizeComplexScript() { Val = "28" };
            Languages languages25 = new Languages() { Val = "en-US" };

            paragraphMarkRunProperties18.Append(italic27);
            paragraphMarkRunProperties18.Append(fontSize36);
            paragraphMarkRunProperties18.Append(fontSizeComplexScript36);
            paragraphMarkRunProperties18.Append(languages25);

            paragraphProperties47.Append(justification43);
            paragraphProperties47.Append(paragraphMarkRunProperties18);

            Run run41 = new Run() { RsidRunProperties = "00E96696" };

            RunProperties runProperties22 = new RunProperties();
            Italic italic28 = new Italic();
            FontSize fontSize37 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript37 = new FontSizeComplexScript() { Val = "28" };
            Languages languages26 = new Languages() { Val = "en-US" };

            runProperties22.Append(italic28);
            runProperties22.Append(fontSize37);
            runProperties22.Append(fontSizeComplexScript37);
            runProperties22.Append(languages26);
            Text text41 = new Text();
            text41.Text = "#grp2";

            run41.Append(runProperties22);
            run41.Append(text41);

            paragraph48.Append(paragraphProperties47);
            paragraph48.Append(run41);

            tableCell37.Append(tableCellProperties37);
            tableCell37.Append(paragraph48);

            TableCell tableCell38 = new TableCell();

            TableCellProperties tableCellProperties38 = new TableCellProperties();
            TableCellWidth tableCellWidth38 = new TableCellWidth() { Width = "1080", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan27 = new GridSpan() { Val = 4 };

            TableCellBorders tableCellBorders38 = new TableCellBorders();
            TopBorder topBorder41 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder41 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder40 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder41 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders38.Append(topBorder41);
            tableCellBorders38.Append(leftBorder41);
            tableCellBorders38.Append(bottomBorder40);
            tableCellBorders38.Append(rightBorder41);
            Shading shading38 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties38.Append(tableCellWidth38);
            tableCellProperties38.Append(gridSpan27);
            tableCellProperties38.Append(tableCellBorders38);
            tableCellProperties38.Append(shading38);

            Paragraph paragraph49 = new Paragraph() { RsidParagraphAddition = "000A7E3D", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "000A7E3D" };

            ParagraphProperties paragraphProperties48 = new ParagraphProperties();
            Justification justification44 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties48.Append(justification44);

            Run run42 = new Run();
            Text text42 = new Text();
            text42.Text = "4-й курс";

            run42.Append(text42);

            paragraph49.Append(paragraphProperties48);
            paragraph49.Append(run42);

            tableCell38.Append(tableCellProperties38);
            tableCell38.Append(paragraph49);

            TableCell tableCell39 = new TableCell();

            TableCellProperties tableCellProperties39 = new TableCellProperties();
            TableCellWidth tableCellWidth39 = new TableCellWidth() { Width = "2555", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan28 = new GridSpan() { Val = 2 };

            TableCellBorders tableCellBorders39 = new TableCellBorders();
            TopBorder topBorder42 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder42 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder41 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder42 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders39.Append(topBorder42);
            tableCellBorders39.Append(leftBorder42);
            tableCellBorders39.Append(bottomBorder41);
            tableCellBorders39.Append(rightBorder42);
            Shading shading39 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties39.Append(tableCellWidth39);
            tableCellProperties39.Append(gridSpan28);
            tableCellProperties39.Append(tableCellBorders39);
            tableCellProperties39.Append(shading39);

            Paragraph paragraph50 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "000A7E3D", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "000A7E3D" };

            ParagraphProperties paragraphProperties49 = new ParagraphProperties();
            Justification justification45 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties19 = new ParagraphMarkRunProperties();
            Italic italic29 = new Italic();
            FontSize fontSize38 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript38 = new FontSizeComplexScript() { Val = "26" };
            Languages languages27 = new Languages() { Val = "en-US" };

            paragraphMarkRunProperties19.Append(italic29);
            paragraphMarkRunProperties19.Append(fontSize38);
            paragraphMarkRunProperties19.Append(fontSizeComplexScript38);
            paragraphMarkRunProperties19.Append(languages27);

            paragraphProperties49.Append(justification45);
            paragraphProperties49.Append(paragraphMarkRunProperties19);

            Run run43 = new Run() { RsidRunProperties = "00E96696" };

            RunProperties runProperties23 = new RunProperties();
            Italic italic30 = new Italic();
            FontSize fontSize39 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript39 = new FontSizeComplexScript() { Val = "26" };
            Languages languages28 = new Languages() { Val = "en-US" };

            runProperties23.Append(italic30);
            runProperties23.Append(fontSize39);
            runProperties23.Append(fontSizeComplexScript39);
            runProperties23.Append(languages28);
            Text text43 = new Text();
            text43.Text = "#grp4";

            run43.Append(runProperties23);
            run43.Append(text43);

            paragraph50.Append(paragraphProperties49);
            paragraph50.Append(run43);

            tableCell39.Append(tableCellProperties39);
            tableCell39.Append(paragraph50);

            TableCell tableCell40 = new TableCell();

            TableCellProperties tableCellProperties40 = new TableCellProperties();
            TableCellWidth tableCellWidth40 = new TableCellWidth() { Width = "505", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders40 = new TableCellBorders();
            TopBorder topBorder43 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder43 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder42 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder43 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders40.Append(topBorder43);
            tableCellBorders40.Append(leftBorder43);
            tableCellBorders40.Append(bottomBorder42);
            tableCellBorders40.Append(rightBorder43);
            Shading shading40 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties40.Append(tableCellWidth40);
            tableCellProperties40.Append(tableCellBorders40);
            tableCellProperties40.Append(shading40);

            Paragraph paragraph51 = new Paragraph() { RsidParagraphAddition = "000A7E3D", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "000A7E3D" };

            ParagraphProperties paragraphProperties50 = new ParagraphProperties();
            Justification justification46 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties50.Append(justification46);

            paragraph51.Append(paragraphProperties50);

            tableCell40.Append(tableCellProperties40);
            tableCell40.Append(paragraph51);

            TableCell tableCell41 = new TableCell();

            TableCellProperties tableCellProperties41 = new TableCellProperties();
            TableCellWidth tableCellWidth41 = new TableCellWidth() { Width = "6480", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan29 = new GridSpan() { Val = 8 };

            TableCellBorders tableCellBorders41 = new TableCellBorders();
            TopBorder topBorder44 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder44 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder43 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder44 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders41.Append(topBorder44);
            tableCellBorders41.Append(leftBorder44);
            tableCellBorders41.Append(bottomBorder43);
            tableCellBorders41.Append(rightBorder44);
            Shading shading41 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties41.Append(tableCellWidth41);
            tableCellProperties41.Append(gridSpan29);
            tableCellProperties41.Append(tableCellBorders41);
            tableCellProperties41.Append(shading41);

            Paragraph paragraph52 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "000A7E3D", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "000A7E3D" };

            ParagraphProperties paragraphProperties51 = new ParagraphProperties();
            Justification justification47 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties20 = new ParagraphMarkRunProperties();
            Italic italic31 = new Italic();
            FontSize fontSize40 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript40 = new FontSizeComplexScript() { Val = "26" };

            paragraphMarkRunProperties20.Append(italic31);
            paragraphMarkRunProperties20.Append(fontSize40);
            paragraphMarkRunProperties20.Append(fontSizeComplexScript40);

            paragraphProperties51.Append(justification47);
            paragraphProperties51.Append(paragraphMarkRunProperties20);

            Run run44 = new Run() { RsidRunProperties = "00E96696" };

            RunProperties runProperties24 = new RunProperties();
            Italic italic32 = new Italic();
            FontSize fontSize41 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript41 = new FontSizeComplexScript() { Val = "26" };
            Languages languages29 = new Languages() { Val = "en-US" };

            runProperties24.Append(italic32);
            runProperties24.Append(fontSize41);
            runProperties24.Append(fontSizeComplexScript41);
            runProperties24.Append(languages29);
            Text text44 = new Text();
            text44.Text = "#parents2";

            run44.Append(runProperties24);
            run44.Append(text44);

            paragraph52.Append(paragraphProperties51);
            paragraph52.Append(run44);

            tableCell41.Append(tableCellProperties41);
            tableCell41.Append(paragraph52);

            tableRow8.Append(tableCell36);
            tableRow8.Append(tableCell37);
            tableRow8.Append(tableCell38);
            tableRow8.Append(tableCell39);
            tableRow8.Append(tableCell40);
            tableRow8.Append(tableCell41);

            TableRow tableRow9 = new TableRow() { RsidTableRowAddition = "0075587B", RsidTableRowProperties = "00E96696" };

            TableCell tableCell42 = new TableCell();

            TableCellProperties tableCellProperties42 = new TableCellProperties();
            TableCellWidth tableCellWidth42 = new TableCellWidth() { Width = "1152", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan30 = new GridSpan() { Val = 2 };

            TableCellBorders tableCellBorders42 = new TableCellBorders();
            TopBorder topBorder45 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder45 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder44 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder45 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders42.Append(topBorder45);
            tableCellBorders42.Append(leftBorder45);
            tableCellBorders42.Append(bottomBorder44);
            tableCellBorders42.Append(rightBorder45);
            Shading shading42 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties42.Append(tableCellWidth42);
            tableCellProperties42.Append(gridSpan30);
            tableCellProperties42.Append(tableCellBorders42);
            tableCellProperties42.Append(shading42);

            Paragraph paragraph53 = new Paragraph() { RsidParagraphAddition = "0075587B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "0075587B" };

            ParagraphProperties paragraphProperties52 = new ParagraphProperties();
            Justification justification48 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties52.Append(justification48);

            Run run45 = new Run();
            Text text45 = new Text();
            text45.Text = "3-й курс";

            run45.Append(text45);

            paragraph53.Append(paragraphProperties52);
            paragraph53.Append(run45);

            tableCell42.Append(tableCellProperties42);
            tableCell42.Append(paragraph53);

            TableCell tableCell43 = new TableCell();

            TableCellProperties tableCellProperties43 = new TableCellProperties();
            TableCellWidth tableCellWidth43 = new TableCellWidth() { Width = "2376", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan31 = new GridSpan() { Val = 7 };

            TableCellBorders tableCellBorders43 = new TableCellBorders();
            TopBorder topBorder46 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder46 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder45 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder46 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders43.Append(topBorder46);
            tableCellBorders43.Append(leftBorder46);
            tableCellBorders43.Append(bottomBorder45);
            tableCellBorders43.Append(rightBorder46);
            Shading shading43 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties43.Append(tableCellWidth43);
            tableCellProperties43.Append(gridSpan31);
            tableCellProperties43.Append(tableCellBorders43);
            tableCellProperties43.Append(shading43);

            Paragraph paragraph54 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "0075587B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "0075587B" };

            ParagraphProperties paragraphProperties53 = new ParagraphProperties();
            Justification justification49 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties21 = new ParagraphMarkRunProperties();
            Italic italic33 = new Italic();
            FontSize fontSize42 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript42 = new FontSizeComplexScript() { Val = "26" };
            Languages languages30 = new Languages() { Val = "en-US" };

            paragraphMarkRunProperties21.Append(italic33);
            paragraphMarkRunProperties21.Append(fontSize42);
            paragraphMarkRunProperties21.Append(fontSizeComplexScript42);
            paragraphMarkRunProperties21.Append(languages30);

            paragraphProperties53.Append(justification49);
            paragraphProperties53.Append(paragraphMarkRunProperties21);

            Run run46 = new Run() { RsidRunProperties = "00E96696" };

            RunProperties runProperties25 = new RunProperties();
            Italic italic34 = new Italic();
            FontSize fontSize43 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript43 = new FontSizeComplexScript() { Val = "26" };
            Languages languages31 = new Languages() { Val = "en-US" };

            runProperties25.Append(italic34);
            runProperties25.Append(fontSize43);
            runProperties25.Append(fontSizeComplexScript43);
            runProperties25.Append(languages31);
            Text text46 = new Text();
            text46.Text = "#grp3";

            run46.Append(runProperties25);
            run46.Append(text46);

            paragraph54.Append(paragraphProperties53);
            paragraph54.Append(run46);

            tableCell43.Append(tableCellProperties43);
            tableCell43.Append(paragraph54);

            TableCell tableCell44 = new TableCell();

            TableCellProperties tableCellProperties44 = new TableCellProperties();
            TableCellWidth tableCellWidth44 = new TableCellWidth() { Width = "1080", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan32 = new GridSpan() { Val = 4 };

            TableCellBorders tableCellBorders44 = new TableCellBorders();
            TopBorder topBorder47 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder47 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder46 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder47 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders44.Append(topBorder47);
            tableCellBorders44.Append(leftBorder47);
            tableCellBorders44.Append(bottomBorder46);
            tableCellBorders44.Append(rightBorder47);
            Shading shading44 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties44.Append(tableCellWidth44);
            tableCellProperties44.Append(gridSpan32);
            tableCellProperties44.Append(tableCellBorders44);
            tableCellProperties44.Append(shading44);

            Paragraph paragraph55 = new Paragraph() { RsidParagraphAddition = "0075587B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "0075587B" };

            ParagraphProperties paragraphProperties54 = new ParagraphProperties();
            Justification justification50 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties54.Append(justification50);

            Run run47 = new Run();
            Text text47 = new Text();
            text47.Text = "5-й курс";

            run47.Append(text47);

            paragraph55.Append(paragraphProperties54);
            paragraph55.Append(run47);

            tableCell44.Append(tableCellProperties44);
            tableCell44.Append(paragraph55);

            TableCell tableCell45 = new TableCell();

            TableCellProperties tableCellProperties45 = new TableCellProperties();
            TableCellWidth tableCellWidth45 = new TableCellWidth() { Width = "2555", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan33 = new GridSpan() { Val = 2 };

            TableCellBorders tableCellBorders45 = new TableCellBorders();
            TopBorder topBorder48 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder48 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder47 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder48 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders45.Append(topBorder48);
            tableCellBorders45.Append(leftBorder48);
            tableCellBorders45.Append(bottomBorder47);
            tableCellBorders45.Append(rightBorder48);
            Shading shading45 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties45.Append(tableCellWidth45);
            tableCellProperties45.Append(gridSpan33);
            tableCellProperties45.Append(tableCellBorders45);
            tableCellProperties45.Append(shading45);

            Paragraph paragraph56 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "0075587B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "0075587B" };

            ParagraphProperties paragraphProperties55 = new ParagraphProperties();
            Justification justification51 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties22 = new ParagraphMarkRunProperties();
            Italic italic35 = new Italic();
            FontSize fontSize44 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript44 = new FontSizeComplexScript() { Val = "26" };
            Languages languages32 = new Languages() { Val = "en-US" };

            paragraphMarkRunProperties22.Append(italic35);
            paragraphMarkRunProperties22.Append(fontSize44);
            paragraphMarkRunProperties22.Append(fontSizeComplexScript44);
            paragraphMarkRunProperties22.Append(languages32);

            paragraphProperties55.Append(justification51);
            paragraphProperties55.Append(paragraphMarkRunProperties22);

            Run run48 = new Run() { RsidRunProperties = "00E96696" };

            RunProperties runProperties26 = new RunProperties();
            Italic italic36 = new Italic();
            FontSize fontSize45 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript45 = new FontSizeComplexScript() { Val = "26" };
            Languages languages33 = new Languages() { Val = "en-US" };

            runProperties26.Append(italic36);
            runProperties26.Append(fontSize45);
            runProperties26.Append(fontSizeComplexScript45);
            runProperties26.Append(languages33);
            Text text48 = new Text();
            text48.Text = "#grp5";

            run48.Append(runProperties26);
            run48.Append(text48);

            paragraph56.Append(paragraphProperties55);
            paragraph56.Append(run48);

            tableCell45.Append(tableCellProperties45);
            tableCell45.Append(paragraph56);

            TableCell tableCell46 = new TableCell();

            TableCellProperties tableCellProperties46 = new TableCellProperties();
            TableCellWidth tableCellWidth46 = new TableCellWidth() { Width = "505", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders46 = new TableCellBorders();
            TopBorder topBorder49 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder49 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder48 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder49 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders46.Append(topBorder49);
            tableCellBorders46.Append(leftBorder49);
            tableCellBorders46.Append(bottomBorder48);
            tableCellBorders46.Append(rightBorder49);
            Shading shading46 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties46.Append(tableCellWidth46);
            tableCellProperties46.Append(tableCellBorders46);
            tableCellProperties46.Append(shading46);

            Paragraph paragraph57 = new Paragraph() { RsidParagraphAddition = "0075587B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "0075587B" };

            ParagraphProperties paragraphProperties56 = new ParagraphProperties();
            Justification justification52 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties56.Append(justification52);

            paragraph57.Append(paragraphProperties56);

            tableCell46.Append(tableCellProperties46);
            tableCell46.Append(paragraph57);

            TableCell tableCell47 = new TableCell();

            TableCellProperties tableCellProperties47 = new TableCellProperties();
            TableCellWidth tableCellWidth47 = new TableCellWidth() { Width = "6480", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan34 = new GridSpan() { Val = 8 };

            TableCellBorders tableCellBorders47 = new TableCellBorders();
            TopBorder topBorder50 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder50 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder49 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder50 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders47.Append(topBorder50);
            tableCellBorders47.Append(leftBorder50);
            tableCellBorders47.Append(bottomBorder49);
            tableCellBorders47.Append(rightBorder50);
            Shading shading47 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties47.Append(tableCellWidth47);
            tableCellProperties47.Append(gridSpan34);
            tableCellProperties47.Append(tableCellBorders47);
            tableCellProperties47.Append(shading47);

            Paragraph paragraph58 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "0075587B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "0075587B" };

            ParagraphProperties paragraphProperties57 = new ParagraphProperties();
            Justification justification53 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties23 = new ParagraphMarkRunProperties();
            Italic italic37 = new Italic();
            FontSize fontSize46 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript46 = new FontSizeComplexScript() { Val = "26" };

            paragraphMarkRunProperties23.Append(italic37);
            paragraphMarkRunProperties23.Append(fontSize46);
            paragraphMarkRunProperties23.Append(fontSizeComplexScript46);

            paragraphProperties57.Append(justification53);
            paragraphProperties57.Append(paragraphMarkRunProperties23);

            Run run49 = new Run() { RsidRunProperties = "00E96696" };

            RunProperties runProperties27 = new RunProperties();
            Italic italic38 = new Italic();
            FontSize fontSize47 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript47 = new FontSizeComplexScript() { Val = "26" };
            Languages languages34 = new Languages() { Val = "en-US" };

            runProperties27.Append(italic38);
            runProperties27.Append(fontSize47);
            runProperties27.Append(fontSizeComplexScript47);
            runProperties27.Append(languages34);
            Text text49 = new Text();
            text49.Text = "#parents";

            run49.Append(runProperties27);
            run49.Append(text49);

            Run run50 = new Run() { RsidRunProperties = "00E96696" };

            RunProperties runProperties28 = new RunProperties();
            Italic italic39 = new Italic();
            FontSize fontSize48 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript48 = new FontSizeComplexScript() { Val = "26" };

            runProperties28.Append(italic39);
            runProperties28.Append(fontSize48);
            runProperties28.Append(fontSizeComplexScript48);
            Text text50 = new Text();
            text50.Text = "3";

            run50.Append(runProperties28);
            run50.Append(text50);

            paragraph58.Append(paragraphProperties57);
            paragraph58.Append(run49);
            paragraph58.Append(run50);

            tableCell47.Append(tableCellProperties47);
            tableCell47.Append(paragraph58);

            tableRow9.Append(tableCell42);
            tableRow9.Append(tableCell43);
            tableRow9.Append(tableCell44);
            tableRow9.Append(tableCell45);
            tableRow9.Append(tableCell46);
            tableRow9.Append(tableCell47);

            TableRow tableRow10 = new TableRow() { RsidTableRowAddition = "00F93A6C", RsidTableRowProperties = "00E96696" };

            TableRowProperties tableRowProperties2 = new TableRowProperties();
            GridAfter gridAfter1 = new GridAfter() { Val = 4 };
            WidthAfterTableRow widthAfterTableRow1 = new WidthAfterTableRow() { Width = "2656", Type = TableWidthUnitValues.Dxa };

            tableRowProperties2.Append(gridAfter1);
            tableRowProperties2.Append(widthAfterTableRow1);

            TableCell tableCell48 = new TableCell();

            TableCellProperties tableCellProperties48 = new TableCellProperties();
            TableCellWidth tableCellWidth48 = new TableCellWidth() { Width = "4428", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan35 = new GridSpan() { Val = 12 };

            TableCellBorders tableCellBorders48 = new TableCellBorders();
            TopBorder topBorder51 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder51 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder50 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder51 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders48.Append(topBorder51);
            tableCellBorders48.Append(leftBorder51);
            tableCellBorders48.Append(bottomBorder50);
            tableCellBorders48.Append(rightBorder51);
            Shading shading48 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties48.Append(tableCellWidth48);
            tableCellProperties48.Append(gridSpan35);
            tableCellProperties48.Append(tableCellBorders48);
            tableCellProperties48.Append(shading48);

            Paragraph paragraph59 = new Paragraph() { RsidParagraphMarkRevision = "00200F1F", RsidParagraphAddition = "00F93A6C", RsidParagraphProperties = "00200F1F", RsidRunAdditionDefault = "00F93A6C" };

            Run run51 = new Run() { RsidRunProperties = "00200F1F" };
            Text text51 = new Text();
            text51.Text = "Служба в Вооружённых Силах, звание:";

            run51.Append(text51);

            paragraph59.Append(run51);

            tableCell48.Append(tableCellProperties48);
            tableCell48.Append(paragraph59);

            TableCell tableCell49 = new TableCell();

            TableCellProperties tableCellProperties49 = new TableCellProperties();
            TableCellWidth tableCellWidth49 = new TableCellWidth() { Width = "2735", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan36 = new GridSpan() { Val = 3 };

            TableCellBorders tableCellBorders49 = new TableCellBorders();
            TopBorder topBorder52 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder52 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder51 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder52 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders49.Append(topBorder52);
            tableCellBorders49.Append(leftBorder52);
            tableCellBorders49.Append(bottomBorder51);
            tableCellBorders49.Append(rightBorder52);
            Shading shading49 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties49.Append(tableCellWidth49);
            tableCellProperties49.Append(gridSpan36);
            tableCellProperties49.Append(tableCellBorders49);
            tableCellProperties49.Append(shading49);

            Paragraph paragraph60 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "00F93A6C", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00F93A6C" };

            ParagraphProperties paragraphProperties58 = new ParagraphProperties();
            Justification justification54 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties24 = new ParagraphMarkRunProperties();
            Italic italic40 = new Italic();
            FontSize fontSize49 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript49 = new FontSizeComplexScript() { Val = "26" };
            Languages languages35 = new Languages() { Val = "en-US" };

            paragraphMarkRunProperties24.Append(italic40);
            paragraphMarkRunProperties24.Append(fontSize49);
            paragraphMarkRunProperties24.Append(fontSizeComplexScript49);
            paragraphMarkRunProperties24.Append(languages35);

            paragraphProperties58.Append(justification54);
            paragraphProperties58.Append(paragraphMarkRunProperties24);

            Run run52 = new Run() { RsidRunProperties = "00E96696" };

            RunProperties runProperties29 = new RunProperties();
            Italic italic41 = new Italic();
            FontSize fontSize50 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript50 = new FontSizeComplexScript() { Val = "26" };
            Languages languages36 = new Languages() { Val = "en-US" };

            runProperties29.Append(italic41);
            runProperties29.Append(fontSize50);
            runProperties29.Append(fontSizeComplexScript50);
            runProperties29.Append(languages36);
            Text text52 = new Text();
            text52.Text = "#milduty";

            run52.Append(runProperties29);
            run52.Append(text52);

            paragraph60.Append(paragraphProperties58);
            paragraph60.Append(run52);

            tableCell49.Append(tableCellProperties49);
            tableCell49.Append(paragraph60);

            TableCell tableCell50 = new TableCell();

            TableCellProperties tableCellProperties50 = new TableCellProperties();
            TableCellWidth tableCellWidth50 = new TableCellWidth() { Width = "505", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders50 = new TableCellBorders();
            TopBorder topBorder53 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder53 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder52 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder53 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders50.Append(topBorder53);
            tableCellBorders50.Append(leftBorder53);
            tableCellBorders50.Append(bottomBorder52);
            tableCellBorders50.Append(rightBorder53);
            Shading shading50 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties50.Append(tableCellWidth50);
            tableCellProperties50.Append(tableCellBorders50);
            tableCellProperties50.Append(shading50);

            Paragraph paragraph61 = new Paragraph() { RsidParagraphAddition = "00F93A6C", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00F93A6C" };

            ParagraphProperties paragraphProperties59 = new ParagraphProperties();
            Justification justification55 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties59.Append(justification55);

            paragraph61.Append(paragraphProperties59);

            tableCell50.Append(tableCellProperties50);
            tableCell50.Append(paragraph61);

            TableCell tableCell51 = new TableCell();

            TableCellProperties tableCellProperties51 = new TableCellProperties();
            TableCellWidth tableCellWidth51 = new TableCellWidth() { Width = "3824", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan37 = new GridSpan() { Val = 4 };

            TableCellBorders tableCellBorders51 = new TableCellBorders();
            TopBorder topBorder54 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder54 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder53 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder54 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders51.Append(topBorder54);
            tableCellBorders51.Append(leftBorder54);
            tableCellBorders51.Append(bottomBorder53);
            tableCellBorders51.Append(rightBorder54);
            Shading shading51 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties51.Append(tableCellWidth51);
            tableCellProperties51.Append(gridSpan37);
            tableCellProperties51.Append(tableCellBorders51);
            tableCellProperties51.Append(shading51);

            Paragraph paragraph62 = new Paragraph() { RsidParagraphMarkRevision = "004C4782", RsidParagraphAddition = "00F93A6C", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00F93A6C" };

            ParagraphProperties paragraphProperties60 = new ParagraphProperties();
            Indentation indentation14 = new Indentation() { Left = "-108", Right = "-63" };
            Justification justification56 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties60.Append(indentation14);
            paragraphProperties60.Append(justification56);

            Run run53 = new Run() { RsidRunProperties = "004C4782" };
            Text text53 = new Text();
            text53.Text = "Адрес студента(в настоящее время)";

            run53.Append(text53);

            paragraph62.Append(paragraphProperties60);
            paragraph62.Append(run53);

            tableCell51.Append(tableCellProperties51);
            tableCell51.Append(paragraph62);

            tableRow10.Append(tableRowProperties2);
            tableRow10.Append(tableCell48);
            tableRow10.Append(tableCell49);
            tableRow10.Append(tableCell50);
            tableRow10.Append(tableCell51);

            TableRow tableRow11 = new TableRow() { RsidTableRowAddition = "0075587B", RsidTableRowProperties = "00E96696" };

            TableCell tableCell52 = new TableCell();

            TableCellProperties tableCellProperties52 = new TableCellProperties();
            TableCellWidth tableCellWidth52 = new TableCellWidth() { Width = "7163", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan38 = new GridSpan() { Val = 15 };

            TableCellBorders tableCellBorders52 = new TableCellBorders();
            TopBorder topBorder55 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder55 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder54 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder55 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders52.Append(topBorder55);
            tableCellBorders52.Append(leftBorder55);
            tableCellBorders52.Append(bottomBorder54);
            tableCellBorders52.Append(rightBorder55);
            Shading shading52 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties52.Append(tableCellWidth52);
            tableCellProperties52.Append(gridSpan38);
            tableCellProperties52.Append(tableCellBorders52);
            tableCellProperties52.Append(shading52);

            Paragraph paragraph63 = new Paragraph() { RsidParagraphAddition = "0075587B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "0075587B" };

            ParagraphProperties paragraphProperties61 = new ParagraphProperties();
            Justification justification57 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties61.Append(justification57);

            paragraph63.Append(paragraphProperties61);

            tableCell52.Append(tableCellProperties52);
            tableCell52.Append(paragraph63);

            TableCell tableCell53 = new TableCell();

            TableCellProperties tableCellProperties53 = new TableCellProperties();
            TableCellWidth tableCellWidth53 = new TableCellWidth() { Width = "505", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders53 = new TableCellBorders();
            TopBorder topBorder56 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder56 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder55 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder56 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders53.Append(topBorder56);
            tableCellBorders53.Append(leftBorder56);
            tableCellBorders53.Append(bottomBorder55);
            tableCellBorders53.Append(rightBorder56);
            Shading shading53 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties53.Append(tableCellWidth53);
            tableCellProperties53.Append(tableCellBorders53);
            tableCellProperties53.Append(shading53);

            Paragraph paragraph64 = new Paragraph() { RsidParagraphAddition = "0075587B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "0075587B" };

            ParagraphProperties paragraphProperties62 = new ParagraphProperties();
            Justification justification58 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties62.Append(justification58);

            paragraph64.Append(paragraphProperties62);

            tableCell53.Append(tableCellProperties53);
            tableCell53.Append(paragraph64);

            TableCell tableCell54 = new TableCell();

            TableCellProperties tableCellProperties54 = new TableCellProperties();
            TableCellWidth tableCellWidth54 = new TableCellWidth() { Width = "6480", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan39 = new GridSpan() { Val = 8 };

            TableCellBorders tableCellBorders54 = new TableCellBorders();
            TopBorder topBorder57 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder57 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder56 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder57 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders54.Append(topBorder57);
            tableCellBorders54.Append(leftBorder57);
            tableCellBorders54.Append(bottomBorder56);
            tableCellBorders54.Append(rightBorder57);
            Shading shading54 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties54.Append(tableCellWidth54);
            tableCellProperties54.Append(gridSpan39);
            tableCellProperties54.Append(tableCellBorders54);
            tableCellProperties54.Append(shading54);

            Paragraph paragraph65 = new Paragraph() { RsidParagraphMarkRevision = "00F93A6C", RsidParagraphAddition = "0075587B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "0075587B" };

            ParagraphProperties paragraphProperties63 = new ParagraphProperties();
            Justification justification59 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties63.Append(justification59);

            Run run54 = new Run() { RsidRunProperties = "00E96696" };

            RunProperties runProperties30 = new RunProperties();
            Italic italic42 = new Italic();
            FontSize fontSize51 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript51 = new FontSizeComplexScript() { Val = "26" };
            Languages languages37 = new Languages() { Val = "en-US" };

            runProperties30.Append(italic42);
            runProperties30.Append(fontSize51);
            runProperties30.Append(fontSizeComplexScript51);
            runProperties30.Append(languages37);
            Text text54 = new Text();
            text54.Text = "#address";

            run54.Append(runProperties30);
            run54.Append(text54);

            paragraph65.Append(paragraphProperties63);
            paragraph65.Append(run54);

            tableCell54.Append(tableCellProperties54);
            tableCell54.Append(paragraph65);

            tableRow11.Append(tableCell52);
            tableRow11.Append(tableCell53);
            tableRow11.Append(tableCell54);

            TableRow tableRow12 = new TableRow() { RsidTableRowAddition = "0075587B", RsidTableRowProperties = "00E96696" };

            TableCell tableCell55 = new TableCell();

            TableCellProperties tableCellProperties55 = new TableCellProperties();
            TableCellWidth tableCellWidth55 = new TableCellWidth() { Width = "3708", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan40 = new GridSpan() { Val = 10 };

            TableCellBorders tableCellBorders55 = new TableCellBorders();
            TopBorder topBorder58 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder58 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder57 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder58 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders55.Append(topBorder58);
            tableCellBorders55.Append(leftBorder58);
            tableCellBorders55.Append(bottomBorder57);
            tableCellBorders55.Append(rightBorder58);
            Shading shading55 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties55.Append(tableCellWidth55);
            tableCellProperties55.Append(gridSpan40);
            tableCellProperties55.Append(tableCellBorders55);
            tableCellProperties55.Append(shading55);

            Paragraph paragraph66 = new Paragraph() { RsidParagraphMarkRevision = "00200F1F", RsidParagraphAddition = "0075587B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "0075587B" };

            ParagraphProperties paragraphProperties64 = new ParagraphProperties();
            Justification justification60 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties64.Append(justification60);

            Run run55 = new Run() { RsidRunProperties = "00200F1F" };
            Text text55 = new Text();
            text55.Text = "Приведение к военной присяге:";

            run55.Append(text55);

            paragraph66.Append(paragraphProperties64);
            paragraph66.Append(run55);

            tableCell55.Append(tableCellProperties55);
            tableCell55.Append(paragraph66);

            TableCell tableCell56 = new TableCell();

            TableCellProperties tableCellProperties56 = new TableCellProperties();
            TableCellWidth tableCellWidth56 = new TableCellWidth() { Width = "3455", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan41 = new GridSpan() { Val = 5 };

            TableCellBorders tableCellBorders56 = new TableCellBorders();
            TopBorder topBorder59 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder59 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder58 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder59 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders56.Append(topBorder59);
            tableCellBorders56.Append(leftBorder59);
            tableCellBorders56.Append(bottomBorder58);
            tableCellBorders56.Append(rightBorder59);
            Shading shading56 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties56.Append(tableCellWidth56);
            tableCellProperties56.Append(gridSpan41);
            tableCellProperties56.Append(tableCellBorders56);
            tableCellProperties56.Append(shading56);

            Paragraph paragraph67 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "0075587B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "0075587B" };

            ParagraphProperties paragraphProperties65 = new ParagraphProperties();
            Justification justification61 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties25 = new ParagraphMarkRunProperties();
            Languages languages38 = new Languages() { Val = "en-US" };

            paragraphMarkRunProperties25.Append(languages38);

            paragraphProperties65.Append(justification61);
            paragraphProperties65.Append(paragraphMarkRunProperties25);

            paragraph67.Append(paragraphProperties65);

            tableCell56.Append(tableCellProperties56);
            tableCell56.Append(paragraph67);

            TableCell tableCell57 = new TableCell();

            TableCellProperties tableCellProperties57 = new TableCellProperties();
            TableCellWidth tableCellWidth57 = new TableCellWidth() { Width = "505", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders57 = new TableCellBorders();
            TopBorder topBorder60 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder60 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder59 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder60 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders57.Append(topBorder60);
            tableCellBorders57.Append(leftBorder60);
            tableCellBorders57.Append(bottomBorder59);
            tableCellBorders57.Append(rightBorder60);
            Shading shading57 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties57.Append(tableCellWidth57);
            tableCellProperties57.Append(tableCellBorders57);
            tableCellProperties57.Append(shading57);

            Paragraph paragraph68 = new Paragraph() { RsidParagraphAddition = "0075587B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "0075587B" };

            ParagraphProperties paragraphProperties66 = new ParagraphProperties();
            Justification justification62 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties66.Append(justification62);

            paragraph68.Append(paragraphProperties66);

            tableCell57.Append(tableCellProperties57);
            tableCell57.Append(paragraph68);

            TableCell tableCell58 = new TableCell();

            TableCellProperties tableCellProperties58 = new TableCellProperties();
            TableCellWidth tableCellWidth58 = new TableCellWidth() { Width = "2880", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan42 = new GridSpan() { Val = 2 };

            TableCellBorders tableCellBorders58 = new TableCellBorders();
            TopBorder topBorder61 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder61 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder60 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder61 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders58.Append(topBorder61);
            tableCellBorders58.Append(leftBorder61);
            tableCellBorders58.Append(bottomBorder60);
            tableCellBorders58.Append(rightBorder61);
            Shading shading58 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties58.Append(tableCellWidth58);
            tableCellProperties58.Append(gridSpan42);
            tableCellProperties58.Append(tableCellBorders58);
            tableCellProperties58.Append(shading58);

            Paragraph paragraph69 = new Paragraph() { RsidParagraphAddition = "0075587B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "0075587B" };

            ParagraphProperties paragraphProperties67 = new ParagraphProperties();
            Justification justification63 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties67.Append(justification63);

            Run run56 = new Run();
            Text text56 = new Text();
            text56.Text = "Заключение медкомиссии";

            run56.Append(text56);

            paragraph69.Append(paragraphProperties67);
            paragraph69.Append(run56);

            tableCell58.Append(tableCellProperties58);
            tableCell58.Append(paragraph69);

            TableCell tableCell59 = new TableCell();

            TableCellProperties tableCellProperties59 = new TableCellProperties();
            TableCellWidth tableCellWidth59 = new TableCellWidth() { Width = "3600", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan43 = new GridSpan() { Val = 6 };

            TableCellBorders tableCellBorders59 = new TableCellBorders();
            TopBorder topBorder62 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder62 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder61 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder62 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders59.Append(topBorder62);
            tableCellBorders59.Append(leftBorder62);
            tableCellBorders59.Append(bottomBorder61);
            tableCellBorders59.Append(rightBorder62);
            Shading shading59 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties59.Append(tableCellWidth59);
            tableCellProperties59.Append(gridSpan43);
            tableCellProperties59.Append(tableCellBorders59);
            tableCellProperties59.Append(shading59);

            Paragraph paragraph70 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "0075587B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "0075587B" };

            ParagraphProperties paragraphProperties68 = new ParagraphProperties();
            Justification justification64 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties26 = new ParagraphMarkRunProperties();
            Italic italic43 = new Italic();
            FontSize fontSize52 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript52 = new FontSizeComplexScript() { Val = "26" };
            Languages languages39 = new Languages() { Val = "en-US" };

            paragraphMarkRunProperties26.Append(italic43);
            paragraphMarkRunProperties26.Append(fontSize52);
            paragraphMarkRunProperties26.Append(fontSizeComplexScript52);
            paragraphMarkRunProperties26.Append(languages39);

            paragraphProperties68.Append(justification64);
            paragraphProperties68.Append(paragraphMarkRunProperties26);

            Run run57 = new Run() { RsidRunProperties = "00E96696" };

            RunProperties runProperties31 = new RunProperties();
            Italic italic44 = new Italic();
            FontSize fontSize53 = new FontSize() { Val = "26" };
            FontSizeComplexScript fontSizeComplexScript53 = new FontSizeComplexScript() { Val = "26" };
            Languages languages40 = new Languages() { Val = "en-US" };

            runProperties31.Append(italic44);
            runProperties31.Append(fontSize53);
            runProperties31.Append(fontSizeComplexScript53);
            runProperties31.Append(languages40);
            Text text57 = new Text();
            text57.Text = "#medcom";

            run57.Append(runProperties31);
            run57.Append(text57);

            paragraph70.Append(paragraphProperties68);
            paragraph70.Append(run57);

            tableCell59.Append(tableCellProperties59);
            tableCell59.Append(paragraph70);

            tableRow12.Append(tableCell55);
            tableRow12.Append(tableCell56);
            tableRow12.Append(tableCell57);
            tableRow12.Append(tableCell58);
            tableRow12.Append(tableCell59);

            TableRow tableRow13 = new TableRow() { RsidTableRowAddition = "0075587B", RsidTableRowProperties = "00E96696" };

            TableCell tableCell60 = new TableCell();

            TableCellProperties tableCellProperties60 = new TableCellProperties();
            TableCellWidth tableCellWidth60 = new TableCellWidth() { Width = "1152", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan44 = new GridSpan() { Val = 2 };

            TableCellBorders tableCellBorders60 = new TableCellBorders();
            TopBorder topBorder63 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder63 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder62 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder63 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders60.Append(topBorder63);
            tableCellBorders60.Append(leftBorder63);
            tableCellBorders60.Append(bottomBorder62);
            tableCellBorders60.Append(rightBorder63);
            Shading shading60 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties60.Append(tableCellWidth60);
            tableCellProperties60.Append(gridSpan44);
            tableCellProperties60.Append(tableCellBorders60);
            tableCellProperties60.Append(shading60);

            Paragraph paragraph71 = new Paragraph() { RsidParagraphAddition = "0075587B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "0075587B" };

            ParagraphProperties paragraphProperties69 = new ParagraphProperties();
            Justification justification65 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties69.Append(justification65);

            paragraph71.Append(paragraphProperties69);

            tableCell60.Append(tableCellProperties60);
            tableCell60.Append(paragraph71);

            TableCell tableCell61 = new TableCell();

            TableCellProperties tableCellProperties61 = new TableCellProperties();
            TableCellWidth tableCellWidth61 = new TableCellWidth() { Width = "2196", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan45 = new GridSpan() { Val = 6 };

            TableCellBorders tableCellBorders61 = new TableCellBorders();
            TopBorder topBorder64 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder64 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder63 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder64 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders61.Append(topBorder64);
            tableCellBorders61.Append(leftBorder64);
            tableCellBorders61.Append(bottomBorder63);
            tableCellBorders61.Append(rightBorder64);
            Shading shading61 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties61.Append(tableCellWidth61);
            tableCellProperties61.Append(gridSpan45);
            tableCellProperties61.Append(tableCellBorders61);
            tableCellProperties61.Append(shading61);

            Paragraph paragraph72 = new Paragraph() { RsidParagraphAddition = "0075587B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "0075587B" };

            ParagraphProperties paragraphProperties70 = new ParagraphProperties();
            Justification justification66 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties70.Append(justification66);

            paragraph72.Append(paragraphProperties70);

            tableCell61.Append(tableCellProperties61);
            tableCell61.Append(paragraph72);

            TableCell tableCell62 = new TableCell();

            TableCellProperties tableCellProperties62 = new TableCellProperties();
            TableCellWidth tableCellWidth62 = new TableCellWidth() { Width = "3815", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan46 = new GridSpan() { Val = 7 };

            TableCellBorders tableCellBorders62 = new TableCellBorders();
            TopBorder topBorder65 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder65 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder64 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder65 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders62.Append(topBorder65);
            tableCellBorders62.Append(leftBorder65);
            tableCellBorders62.Append(bottomBorder64);
            tableCellBorders62.Append(rightBorder65);
            Shading shading62 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties62.Append(tableCellWidth62);
            tableCellProperties62.Append(gridSpan46);
            tableCellProperties62.Append(tableCellBorders62);
            tableCellProperties62.Append(shading62);

            Paragraph paragraph73 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "0075587B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "0075587B" };

            ParagraphProperties paragraphProperties71 = new ParagraphProperties();
            Justification justification67 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties27 = new ParagraphMarkRunProperties();
            FontSize fontSize54 = new FontSize() { Val = "14" };
            FontSizeComplexScript fontSizeComplexScript54 = new FontSizeComplexScript() { Val = "14" };

            paragraphMarkRunProperties27.Append(fontSize54);
            paragraphMarkRunProperties27.Append(fontSizeComplexScript54);

            paragraphProperties71.Append(justification67);
            paragraphProperties71.Append(paragraphMarkRunProperties27);

            Run run58 = new Run() { RsidRunProperties = "00E96696" };

            RunProperties runProperties32 = new RunProperties();
            FontSize fontSize55 = new FontSize() { Val = "14" };
            FontSizeComplexScript fontSizeComplexScript55 = new FontSizeComplexScript() { Val = "14" };

            runProperties32.Append(fontSize55);
            runProperties32.Append(fontSizeComplexScript55);
            Text text58 = new Text();
            text58.Text = "(число, месяц, год)";

            run58.Append(runProperties32);
            run58.Append(text58);

            paragraph73.Append(paragraphProperties71);
            paragraph73.Append(run58);

            tableCell62.Append(tableCellProperties62);
            tableCell62.Append(paragraph73);

            TableCell tableCell63 = new TableCell();

            TableCellProperties tableCellProperties63 = new TableCellProperties();
            TableCellWidth tableCellWidth63 = new TableCellWidth() { Width = "505", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders63 = new TableCellBorders();
            TopBorder topBorder66 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder66 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder65 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder66 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders63.Append(topBorder66);
            tableCellBorders63.Append(leftBorder66);
            tableCellBorders63.Append(bottomBorder65);
            tableCellBorders63.Append(rightBorder66);
            Shading shading63 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties63.Append(tableCellWidth63);
            tableCellProperties63.Append(tableCellBorders63);
            tableCellProperties63.Append(shading63);

            Paragraph paragraph74 = new Paragraph() { RsidParagraphAddition = "0075587B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "0075587B" };

            ParagraphProperties paragraphProperties72 = new ParagraphProperties();
            Justification justification68 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties72.Append(justification68);

            paragraph74.Append(paragraphProperties72);

            tableCell63.Append(tableCellProperties63);
            tableCell63.Append(paragraph74);

            TableCell tableCell64 = new TableCell();

            TableCellProperties tableCellProperties64 = new TableCellProperties();
            TableCellWidth tableCellWidth64 = new TableCellWidth() { Width = "6480", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan47 = new GridSpan() { Val = 8 };

            TableCellBorders tableCellBorders64 = new TableCellBorders();
            TopBorder topBorder67 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder67 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder66 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder67 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders64.Append(topBorder67);
            tableCellBorders64.Append(leftBorder67);
            tableCellBorders64.Append(bottomBorder66);
            tableCellBorders64.Append(rightBorder67);
            Shading shading64 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties64.Append(tableCellWidth64);
            tableCellProperties64.Append(gridSpan47);
            tableCellProperties64.Append(tableCellBorders64);
            tableCellProperties64.Append(shading64);

            Paragraph paragraph75 = new Paragraph() { RsidParagraphAddition = "0075587B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "0075587B" };

            ParagraphProperties paragraphProperties73 = new ParagraphProperties();
            Justification justification69 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties73.Append(justification69);

            paragraph75.Append(paragraphProperties73);

            tableCell64.Append(tableCellProperties64);
            tableCell64.Append(paragraph75);

            tableRow13.Append(tableCell60);
            tableRow13.Append(tableCell61);
            tableRow13.Append(tableCell62);
            tableRow13.Append(tableCell63);
            tableRow13.Append(tableCell64);

            TableRow tableRow14 = new TableRow() { RsidTableRowAddition = "0075587B", RsidTableRowProperties = "00E96696" };

            TableRowProperties tableRowProperties3 = new TableRowProperties();
            TableRowHeight tableRowHeight2 = new TableRowHeight() { Val = (UInt32Value)70U };

            tableRowProperties3.Append(tableRowHeight2);

            TableCell tableCell65 = new TableCell();

            TableCellProperties tableCellProperties65 = new TableCellProperties();
            TableCellWidth tableCellWidth65 = new TableCellWidth() { Width = "1152", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan48 = new GridSpan() { Val = 2 };

            TableCellBorders tableCellBorders65 = new TableCellBorders();
            TopBorder topBorder68 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder68 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder67 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder68 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders65.Append(topBorder68);
            tableCellBorders65.Append(leftBorder68);
            tableCellBorders65.Append(bottomBorder67);
            tableCellBorders65.Append(rightBorder68);
            Shading shading65 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties65.Append(tableCellWidth65);
            tableCellProperties65.Append(gridSpan48);
            tableCellProperties65.Append(tableCellBorders65);
            tableCellProperties65.Append(shading65);

            Paragraph paragraph76 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "0075587B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "0075587B" };

            ParagraphProperties paragraphProperties74 = new ParagraphProperties();
            Justification justification70 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties28 = new ParagraphMarkRunProperties();
            FontSize fontSize56 = new FontSize() { Val = "12" };
            FontSizeComplexScript fontSizeComplexScript56 = new FontSizeComplexScript() { Val = "12" };

            paragraphMarkRunProperties28.Append(fontSize56);
            paragraphMarkRunProperties28.Append(fontSizeComplexScript56);

            paragraphProperties74.Append(justification70);
            paragraphProperties74.Append(paragraphMarkRunProperties28);

            paragraph76.Append(paragraphProperties74);

            tableCell65.Append(tableCellProperties65);
            tableCell65.Append(paragraph76);

            TableCell tableCell66 = new TableCell();

            TableCellProperties tableCellProperties66 = new TableCellProperties();
            TableCellWidth tableCellWidth66 = new TableCellWidth() { Width = "2196", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan49 = new GridSpan() { Val = 6 };

            TableCellBorders tableCellBorders66 = new TableCellBorders();
            TopBorder topBorder69 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder69 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder68 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder69 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders66.Append(topBorder69);
            tableCellBorders66.Append(leftBorder69);
            tableCellBorders66.Append(bottomBorder68);
            tableCellBorders66.Append(rightBorder69);
            Shading shading66 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties66.Append(tableCellWidth66);
            tableCellProperties66.Append(gridSpan49);
            tableCellProperties66.Append(tableCellBorders66);
            tableCellProperties66.Append(shading66);

            Paragraph paragraph77 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "0075587B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "0075587B" };

            ParagraphProperties paragraphProperties75 = new ParagraphProperties();
            Justification justification71 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties29 = new ParagraphMarkRunProperties();
            FontSize fontSize57 = new FontSize() { Val = "12" };
            FontSizeComplexScript fontSizeComplexScript57 = new FontSizeComplexScript() { Val = "12" };

            paragraphMarkRunProperties29.Append(fontSize57);
            paragraphMarkRunProperties29.Append(fontSizeComplexScript57);

            paragraphProperties75.Append(justification71);
            paragraphProperties75.Append(paragraphMarkRunProperties29);

            paragraph77.Append(paragraphProperties75);

            tableCell66.Append(tableCellProperties66);
            tableCell66.Append(paragraph77);

            TableCell tableCell67 = new TableCell();

            TableCellProperties tableCellProperties67 = new TableCellProperties();
            TableCellWidth tableCellWidth67 = new TableCellWidth() { Width = "1738", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan50 = new GridSpan() { Val = 6 };

            TableCellBorders tableCellBorders67 = new TableCellBorders();
            TopBorder topBorder70 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder70 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder69 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder70 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders67.Append(topBorder70);
            tableCellBorders67.Append(leftBorder70);
            tableCellBorders67.Append(bottomBorder69);
            tableCellBorders67.Append(rightBorder70);
            Shading shading67 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties67.Append(tableCellWidth67);
            tableCellProperties67.Append(gridSpan50);
            tableCellProperties67.Append(tableCellBorders67);
            tableCellProperties67.Append(shading67);

            Paragraph paragraph78 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "0075587B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "0075587B" };

            ParagraphProperties paragraphProperties76 = new ParagraphProperties();
            Justification justification72 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties30 = new ParagraphMarkRunProperties();
            FontSize fontSize58 = new FontSize() { Val = "12" };
            FontSizeComplexScript fontSizeComplexScript58 = new FontSizeComplexScript() { Val = "12" };

            paragraphMarkRunProperties30.Append(fontSize58);
            paragraphMarkRunProperties30.Append(fontSizeComplexScript58);

            paragraphProperties76.Append(justification72);
            paragraphProperties76.Append(paragraphMarkRunProperties30);

            paragraph78.Append(paragraphProperties76);

            tableCell67.Append(tableCellProperties67);
            tableCell67.Append(paragraph78);

            TableCell tableCell68 = new TableCell();

            TableCellProperties tableCellProperties68 = new TableCellProperties();
            TableCellWidth tableCellWidth68 = new TableCellWidth() { Width = "2077", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders68 = new TableCellBorders();
            TopBorder topBorder71 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder71 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder70 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder71 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders68.Append(topBorder71);
            tableCellBorders68.Append(leftBorder71);
            tableCellBorders68.Append(bottomBorder70);
            tableCellBorders68.Append(rightBorder71);
            Shading shading68 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties68.Append(tableCellWidth68);
            tableCellProperties68.Append(tableCellBorders68);
            tableCellProperties68.Append(shading68);

            Paragraph paragraph79 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "0075587B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "0075587B" };

            ParagraphProperties paragraphProperties77 = new ParagraphProperties();
            Justification justification73 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties31 = new ParagraphMarkRunProperties();
            FontSize fontSize59 = new FontSize() { Val = "12" };
            FontSizeComplexScript fontSizeComplexScript59 = new FontSizeComplexScript() { Val = "12" };

            paragraphMarkRunProperties31.Append(fontSize59);
            paragraphMarkRunProperties31.Append(fontSizeComplexScript59);

            paragraphProperties77.Append(justification73);
            paragraphProperties77.Append(paragraphMarkRunProperties31);

            paragraph79.Append(paragraphProperties77);

            tableCell68.Append(tableCellProperties68);
            tableCell68.Append(paragraph79);

            TableCell tableCell69 = new TableCell();

            TableCellProperties tableCellProperties69 = new TableCellProperties();
            TableCellWidth tableCellWidth69 = new TableCellWidth() { Width = "505", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders69 = new TableCellBorders();
            TopBorder topBorder72 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder72 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder71 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder72 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders69.Append(topBorder72);
            tableCellBorders69.Append(leftBorder72);
            tableCellBorders69.Append(bottomBorder71);
            tableCellBorders69.Append(rightBorder72);
            Shading shading69 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties69.Append(tableCellWidth69);
            tableCellProperties69.Append(tableCellBorders69);
            tableCellProperties69.Append(shading69);

            Paragraph paragraph80 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "0075587B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "0075587B" };

            ParagraphProperties paragraphProperties78 = new ParagraphProperties();
            Justification justification74 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties32 = new ParagraphMarkRunProperties();
            FontSize fontSize60 = new FontSize() { Val = "12" };
            FontSizeComplexScript fontSizeComplexScript60 = new FontSizeComplexScript() { Val = "12" };

            paragraphMarkRunProperties32.Append(fontSize60);
            paragraphMarkRunProperties32.Append(fontSizeComplexScript60);

            paragraphProperties78.Append(justification74);
            paragraphProperties78.Append(paragraphMarkRunProperties32);

            paragraph80.Append(paragraphProperties78);

            tableCell69.Append(tableCellProperties69);
            tableCell69.Append(paragraph80);

            TableCell tableCell70 = new TableCell();

            TableCellProperties tableCellProperties70 = new TableCellProperties();
            TableCellWidth tableCellWidth70 = new TableCellWidth() { Width = "6480", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan51 = new GridSpan() { Val = 8 };

            TableCellBorders tableCellBorders70 = new TableCellBorders();
            TopBorder topBorder73 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder73 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder72 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder73 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders70.Append(topBorder73);
            tableCellBorders70.Append(leftBorder73);
            tableCellBorders70.Append(bottomBorder72);
            tableCellBorders70.Append(rightBorder73);
            Shading shading70 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties70.Append(tableCellWidth70);
            tableCellProperties70.Append(gridSpan51);
            tableCellProperties70.Append(tableCellBorders70);
            tableCellProperties70.Append(shading70);

            Paragraph paragraph81 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "0075587B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "0075587B" };

            ParagraphProperties paragraphProperties79 = new ParagraphProperties();
            Justification justification75 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties33 = new ParagraphMarkRunProperties();
            FontSize fontSize61 = new FontSize() { Val = "12" };
            FontSizeComplexScript fontSizeComplexScript61 = new FontSizeComplexScript() { Val = "12" };

            paragraphMarkRunProperties33.Append(fontSize61);
            paragraphMarkRunProperties33.Append(fontSizeComplexScript61);

            paragraphProperties79.Append(justification75);
            paragraphProperties79.Append(paragraphMarkRunProperties33);

            Run run59 = new Run() { RsidRunProperties = "00E96696" };

            RunProperties runProperties33 = new RunProperties();
            FontSize fontSize62 = new FontSize() { Val = "12" };
            FontSizeComplexScript fontSizeComplexScript62 = new FontSizeComplexScript() { Val = "12" };

            runProperties33.Append(fontSize62);
            runProperties33.Append(fontSizeComplexScript62);
            Text text59 = new Text();
            text59.Text = "(о годности к военной службе, дата)";

            run59.Append(runProperties33);
            run59.Append(text59);

            paragraph81.Append(paragraphProperties79);
            paragraph81.Append(run59);

            tableCell70.Append(tableCellProperties70);
            tableCell70.Append(paragraph81);

            tableRow14.Append(tableRowProperties3);
            tableRow14.Append(tableCell65);
            tableRow14.Append(tableCell66);
            tableRow14.Append(tableCell67);
            tableRow14.Append(tableCell68);
            tableRow14.Append(tableCell69);
            tableRow14.Append(tableCell70);

            table2.Append(tableProperties2);
            table2.Append(tableGrid2);
            table2.Append(tableRow2);
            table2.Append(tableRow3);
            table2.Append(tableRow4);
            table2.Append(tableRow5);
            table2.Append(tableRow6);
            table2.Append(tableRow7);
            table2.Append(tableRow8);
            table2.Append(tableRow9);
            table2.Append(tableRow10);
            table2.Append(tableRow11);
            table2.Append(tableRow12);
            table2.Append(tableRow13);
            table2.Append(tableRow14);

            Paragraph paragraph82 = new Paragraph() { RsidParagraphAddition = "005F2B37", RsidParagraphProperties = "004C4782", RsidRunAdditionDefault = "004C4782" };

            ParagraphProperties paragraphProperties80 = new ParagraphProperties();
            Indentation indentation15 = new Indentation() { FirstLine = "708" };
            Justification justification76 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties80.Append(indentation15);
            paragraphProperties80.Append(justification76);

            Run run60 = new Run() { RsidRunProperties = "004C4782" };
            Text text60 = new Text();
            text60.Text = "Краткая характеристика успеваемости и дисциплины";

            run60.Append(text60);

            paragraph82.Append(paragraphProperties80);
            paragraph82.Append(run60);

            Table table3 = new Table();

            TableProperties tableProperties3 = new TableProperties();
            TableWidth tableWidth3 = new TableWidth() { Width = "0", Type = TableWidthUnitValues.Auto };

            TableBorders tableBorders3 = new TableBorders();
            BottomBorder bottomBorder73 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableBorders3.Append(bottomBorder73);
            TableLook tableLook3 = new TableLook() { Val = "01E0", FirstRow = true, LastRow = true, FirstColumn = true, LastColumn = true, NoHorizontalBand = false, NoVerticalBand = false };

            tableProperties3.Append(tableWidth3);
            tableProperties3.Append(tableBorders3);
            tableProperties3.Append(tableLook3);

            TableGrid tableGrid3 = new TableGrid();
            GridColumn gridColumn27 = new GridColumn() { Width = "1638" };
            GridColumn gridColumn28 = new GridColumn() { Width = "5490" };
            GridColumn gridColumn29 = new GridColumn() { Width = "7020" };

            tableGrid3.Append(gridColumn27);
            tableGrid3.Append(gridColumn28);
            tableGrid3.Append(gridColumn29);

            TableRow tableRow15 = new TableRow() { RsidTableRowAddition = "004C4782", RsidTableRowProperties = "00E96696" };

            TableCell tableCell71 = new TableCell();

            TableCellProperties tableCellProperties71 = new TableCellProperties();
            TableCellWidth tableCellWidth71 = new TableCellWidth() { Width = "1638", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders71 = new TableCellBorders();
            BottomBorder bottomBorder74 = new BottomBorder() { Val = BorderValues.Nil };

            tableCellBorders71.Append(bottomBorder74);
            Shading shading71 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties71.Append(tableCellWidth71);
            tableCellProperties71.Append(tableCellBorders71);
            tableCellProperties71.Append(shading71);

            Paragraph paragraph83 = new Paragraph() { RsidParagraphAddition = "004C4782", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00AA4DDD" };

            ParagraphProperties paragraphProperties81 = new ParagraphProperties();
            Justification justification77 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties81.Append(justification77);

            Run run61 = new Run();
            Text text61 = new Text();
            text61.Text = "2-й курс";

            run61.Append(text61);

            paragraph83.Append(paragraphProperties81);
            paragraph83.Append(run61);

            tableCell71.Append(tableCellProperties71);
            tableCell71.Append(paragraph83);

            TableCell tableCell72 = new TableCell();

            TableCellProperties tableCellProperties72 = new TableCellProperties();
            TableCellWidth tableCellWidth72 = new TableCellWidth() { Width = "12510", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan52 = new GridSpan() { Val = 2 };

            TableCellBorders tableCellBorders72 = new TableCellBorders();
            BottomBorder bottomBorder75 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders72.Append(bottomBorder75);
            Shading shading72 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties72.Append(tableCellWidth72);
            tableCellProperties72.Append(gridSpan52);
            tableCellProperties72.Append(tableCellBorders72);
            tableCellProperties72.Append(shading72);

            Paragraph paragraph84 = new Paragraph() { RsidParagraphAddition = "004C4782", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "004C4782" };

            ParagraphProperties paragraphProperties82 = new ParagraphProperties();
            Justification justification78 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties82.Append(justification78);

            paragraph84.Append(paragraphProperties82);

            tableCell72.Append(tableCellProperties72);
            tableCell72.Append(paragraph84);

            tableRow15.Append(tableCell71);
            tableRow15.Append(tableCell72);

            TableRow tableRow16 = new TableRow() { RsidTableRowAddition = "004C4782", RsidTableRowProperties = "00E96696" };

            TableCell tableCell73 = new TableCell();

            TableCellProperties tableCellProperties73 = new TableCellProperties();
            TableCellWidth tableCellWidth73 = new TableCellWidth() { Width = "1638", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders73 = new TableCellBorders();
            TopBorder topBorder74 = new TopBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder76 = new BottomBorder() { Val = BorderValues.Nil };

            tableCellBorders73.Append(topBorder74);
            tableCellBorders73.Append(bottomBorder76);
            Shading shading73 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties73.Append(tableCellWidth73);
            tableCellProperties73.Append(tableCellBorders73);
            tableCellProperties73.Append(shading73);

            Paragraph paragraph85 = new Paragraph() { RsidParagraphAddition = "004C4782", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00AA4DDD" };

            ParagraphProperties paragraphProperties83 = new ParagraphProperties();
            Justification justification79 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties83.Append(justification79);

            Run run62 = new Run();
            Text text62 = new Text();
            text62.Text = "3-й курс";

            run62.Append(text62);

            paragraph85.Append(paragraphProperties83);
            paragraph85.Append(run62);

            tableCell73.Append(tableCellProperties73);
            tableCell73.Append(paragraph85);

            TableCell tableCell74 = new TableCell();

            TableCellProperties tableCellProperties74 = new TableCellProperties();
            TableCellWidth tableCellWidth74 = new TableCellWidth() { Width = "12510", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan53 = new GridSpan() { Val = 2 };

            TableCellBorders tableCellBorders74 = new TableCellBorders();
            TopBorder topBorder75 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder77 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders74.Append(topBorder75);
            tableCellBorders74.Append(bottomBorder77);
            Shading shading74 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties74.Append(tableCellWidth74);
            tableCellProperties74.Append(gridSpan53);
            tableCellProperties74.Append(tableCellBorders74);
            tableCellProperties74.Append(shading74);

            Paragraph paragraph86 = new Paragraph() { RsidParagraphAddition = "004C4782", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "004C4782" };

            ParagraphProperties paragraphProperties84 = new ParagraphProperties();
            Justification justification80 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties84.Append(justification80);

            paragraph86.Append(paragraphProperties84);

            tableCell74.Append(tableCellProperties74);
            tableCell74.Append(paragraph86);

            tableRow16.Append(tableCell73);
            tableRow16.Append(tableCell74);

            TableRow tableRow17 = new TableRow() { RsidTableRowAddition = "00AA4DDD", RsidTableRowProperties = "00E96696" };

            TableCell tableCell75 = new TableCell();

            TableCellProperties tableCellProperties75 = new TableCellProperties();
            TableCellWidth tableCellWidth75 = new TableCellWidth() { Width = "14148", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan54 = new GridSpan() { Val = 3 };

            TableCellBorders tableCellBorders75 = new TableCellBorders();
            BottomBorder bottomBorder78 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders75.Append(bottomBorder78);
            Shading shading75 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties75.Append(tableCellWidth75);
            tableCellProperties75.Append(gridSpan54);
            tableCellProperties75.Append(tableCellBorders75);
            tableCellProperties75.Append(shading75);

            Paragraph paragraph87 = new Paragraph() { RsidParagraphAddition = "00AA4DDD", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00AA4DDD" };

            ParagraphProperties paragraphProperties85 = new ParagraphProperties();
            Justification justification81 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties85.Append(justification81);

            paragraph87.Append(paragraphProperties85);

            tableCell75.Append(tableCellProperties75);
            tableCell75.Append(paragraph87);

            tableRow17.Append(tableCell75);

            TableRow tableRow18 = new TableRow() { RsidTableRowAddition = "00AA4DDD", RsidTableRowProperties = "00E96696" };

            TableCell tableCell76 = new TableCell();

            TableCellProperties tableCellProperties76 = new TableCellProperties();
            TableCellWidth tableCellWidth76 = new TableCellWidth() { Width = "1638", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders76 = new TableCellBorders();
            TopBorder topBorder76 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder79 = new BottomBorder() { Val = BorderValues.Nil };

            tableCellBorders76.Append(topBorder76);
            tableCellBorders76.Append(bottomBorder79);
            Shading shading76 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties76.Append(tableCellWidth76);
            tableCellProperties76.Append(tableCellBorders76);
            tableCellProperties76.Append(shading76);

            Paragraph paragraph88 = new Paragraph() { RsidParagraphAddition = "00AA4DDD", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00AA4DDD" };

            ParagraphProperties paragraphProperties86 = new ParagraphProperties();
            Justification justification82 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties86.Append(justification82);

            Run run63 = new Run();
            Text text63 = new Text();
            text63.Text = "4-й курс";

            run63.Append(text63);

            paragraph88.Append(paragraphProperties86);
            paragraph88.Append(run63);

            tableCell76.Append(tableCellProperties76);
            tableCell76.Append(paragraph88);

            TableCell tableCell77 = new TableCell();

            TableCellProperties tableCellProperties77 = new TableCellProperties();
            TableCellWidth tableCellWidth77 = new TableCellWidth() { Width = "12510", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan55 = new GridSpan() { Val = 2 };

            TableCellBorders tableCellBorders77 = new TableCellBorders();
            TopBorder topBorder77 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder80 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders77.Append(topBorder77);
            tableCellBorders77.Append(bottomBorder80);
            Shading shading77 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties77.Append(tableCellWidth77);
            tableCellProperties77.Append(gridSpan55);
            tableCellProperties77.Append(tableCellBorders77);
            tableCellProperties77.Append(shading77);

            Paragraph paragraph89 = new Paragraph() { RsidParagraphAddition = "00AA4DDD", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00AA4DDD" };

            ParagraphProperties paragraphProperties87 = new ParagraphProperties();
            Justification justification83 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties87.Append(justification83);

            paragraph89.Append(paragraphProperties87);

            tableCell77.Append(tableCellProperties77);
            tableCell77.Append(paragraph89);

            tableRow18.Append(tableCell76);
            tableRow18.Append(tableCell77);

            TableRow tableRow19 = new TableRow() { RsidTableRowAddition = "00AA4DDD", RsidTableRowProperties = "00E96696" };

            TableCell tableCell78 = new TableCell();

            TableCellProperties tableCellProperties78 = new TableCellProperties();
            TableCellWidth tableCellWidth78 = new TableCellWidth() { Width = "14148", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan56 = new GridSpan() { Val = 3 };

            TableCellBorders tableCellBorders78 = new TableCellBorders();
            BottomBorder bottomBorder81 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders78.Append(bottomBorder81);
            Shading shading78 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties78.Append(tableCellWidth78);
            tableCellProperties78.Append(gridSpan56);
            tableCellProperties78.Append(tableCellBorders78);
            tableCellProperties78.Append(shading78);

            Paragraph paragraph90 = new Paragraph() { RsidParagraphAddition = "00AA4DDD", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00AA4DDD" };

            ParagraphProperties paragraphProperties88 = new ParagraphProperties();
            Justification justification84 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties88.Append(justification84);

            paragraph90.Append(paragraphProperties88);

            tableCell78.Append(tableCellProperties78);
            tableCell78.Append(paragraph90);

            tableRow19.Append(tableCell78);

            TableRow tableRow20 = new TableRow() { RsidTableRowAddition = "00AA4DDD", RsidTableRowProperties = "00E96696" };

            TableCell tableCell79 = new TableCell();

            TableCellProperties tableCellProperties79 = new TableCellProperties();
            TableCellWidth tableCellWidth79 = new TableCellWidth() { Width = "1638", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders79 = new TableCellBorders();
            TopBorder topBorder78 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder82 = new BottomBorder() { Val = BorderValues.Nil };

            tableCellBorders79.Append(topBorder78);
            tableCellBorders79.Append(bottomBorder82);
            Shading shading79 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties79.Append(tableCellWidth79);
            tableCellProperties79.Append(tableCellBorders79);
            tableCellProperties79.Append(shading79);

            Paragraph paragraph91 = new Paragraph() { RsidParagraphAddition = "00AA4DDD", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00AA4DDD" };

            ParagraphProperties paragraphProperties89 = new ParagraphProperties();
            Justification justification85 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties89.Append(justification85);

            Run run64 = new Run();
            Text text64 = new Text();
            text64.Text = "5-й курс";

            run64.Append(text64);

            paragraph91.Append(paragraphProperties89);
            paragraph91.Append(run64);

            tableCell79.Append(tableCellProperties79);
            tableCell79.Append(paragraph91);

            TableCell tableCell80 = new TableCell();

            TableCellProperties tableCellProperties80 = new TableCellProperties();
            TableCellWidth tableCellWidth80 = new TableCellWidth() { Width = "12510", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan57 = new GridSpan() { Val = 2 };

            TableCellBorders tableCellBorders80 = new TableCellBorders();
            TopBorder topBorder79 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder83 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders80.Append(topBorder79);
            tableCellBorders80.Append(bottomBorder83);
            Shading shading80 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties80.Append(tableCellWidth80);
            tableCellProperties80.Append(gridSpan57);
            tableCellProperties80.Append(tableCellBorders80);
            tableCellProperties80.Append(shading80);

            Paragraph paragraph92 = new Paragraph() { RsidParagraphAddition = "00AA4DDD", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00AA4DDD" };

            ParagraphProperties paragraphProperties90 = new ParagraphProperties();
            Justification justification86 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties90.Append(justification86);

            paragraph92.Append(paragraphProperties90);

            tableCell80.Append(tableCellProperties80);
            tableCell80.Append(paragraph92);

            tableRow20.Append(tableCell79);
            tableRow20.Append(tableCell80);

            TableRow tableRow21 = new TableRow() { RsidTableRowAddition = "00AA4DDD", RsidTableRowProperties = "00E96696" };

            TableCell tableCell81 = new TableCell();

            TableCellProperties tableCellProperties81 = new TableCellProperties();
            TableCellWidth tableCellWidth81 = new TableCellWidth() { Width = "14148", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan58 = new GridSpan() { Val = 3 };

            TableCellBorders tableCellBorders81 = new TableCellBorders();
            BottomBorder bottomBorder84 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders81.Append(bottomBorder84);
            Shading shading81 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties81.Append(tableCellWidth81);
            tableCellProperties81.Append(gridSpan58);
            tableCellProperties81.Append(tableCellBorders81);
            tableCellProperties81.Append(shading81);

            Paragraph paragraph93 = new Paragraph() { RsidParagraphAddition = "00AA4DDD", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00AA4DDD" };

            ParagraphProperties paragraphProperties91 = new ParagraphProperties();
            Justification justification87 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties91.Append(justification87);

            paragraph93.Append(paragraphProperties91);

            tableCell81.Append(tableCellProperties81);
            tableCell81.Append(paragraph93);

            tableRow21.Append(tableCell81);

            TableRow tableRow22 = new TableRow() { RsidTableRowAddition = "00AA4DDD", RsidTableRowProperties = "00E96696" };

            TableCell tableCell82 = new TableCell();

            TableCellProperties tableCellProperties82 = new TableCellProperties();
            TableCellWidth tableCellWidth82 = new TableCellWidth() { Width = "7128", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan59 = new GridSpan() { Val = 2 };

            TableCellBorders tableCellBorders82 = new TableCellBorders();
            TopBorder topBorder80 = new TopBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder85 = new BottomBorder() { Val = BorderValues.Nil };

            tableCellBorders82.Append(topBorder80);
            tableCellBorders82.Append(bottomBorder85);
            Shading shading82 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties82.Append(tableCellWidth82);
            tableCellProperties82.Append(gridSpan59);
            tableCellProperties82.Append(tableCellBorders82);
            tableCellProperties82.Append(shading82);

            Paragraph paragraph94 = new Paragraph() { RsidParagraphMarkRevision = "009E4A5B", RsidParagraphAddition = "00AA4DDD", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "009E4A5B" };

            ParagraphProperties paragraphProperties92 = new ParagraphProperties();
            Justification justification88 = new Justification() { Val = JustificationValues.Right };

            paragraphProperties92.Append(justification88);

            Run run65 = new Run() { RsidRunProperties = "009E4A5B" };
            Text text65 = new Text();
            text65.Text = "Заключение начальника военной кафедры (для аттестования)";

            run65.Append(text65);

            paragraph94.Append(paragraphProperties92);
            paragraph94.Append(run65);

            tableCell82.Append(tableCellProperties82);
            tableCell82.Append(paragraph94);

            TableCell tableCell83 = new TableCell();

            TableCellProperties tableCellProperties83 = new TableCellProperties();
            TableCellWidth tableCellWidth83 = new TableCellWidth() { Width = "7020", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders83 = new TableCellBorders();
            TopBorder topBorder81 = new TopBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder86 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders83.Append(topBorder81);
            tableCellBorders83.Append(bottomBorder86);
            Shading shading83 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties83.Append(tableCellWidth83);
            tableCellProperties83.Append(tableCellBorders83);
            tableCellProperties83.Append(shading83);

            Paragraph paragraph95 = new Paragraph() { RsidParagraphAddition = "00AA4DDD", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00AA4DDD" };

            ParagraphProperties paragraphProperties93 = new ParagraphProperties();
            Justification justification89 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties93.Append(justification89);

            paragraph95.Append(paragraphProperties93);

            tableCell83.Append(tableCellProperties83);
            tableCell83.Append(paragraph95);

            tableRow22.Append(tableCell82);
            tableRow22.Append(tableCell83);

            TableRow tableRow23 = new TableRow() { RsidTableRowAddition = "00763846", RsidTableRowProperties = "00E96696" };

            TableCell tableCell84 = new TableCell();

            TableCellProperties tableCellProperties84 = new TableCellProperties();
            TableCellWidth tableCellWidth84 = new TableCellWidth() { Width = "14148", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan60 = new GridSpan() { Val = 3 };

            TableCellBorders tableCellBorders84 = new TableCellBorders();
            TopBorder topBorder82 = new TopBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder87 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders84.Append(topBorder82);
            tableCellBorders84.Append(bottomBorder87);
            Shading shading84 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties84.Append(tableCellWidth84);
            tableCellProperties84.Append(gridSpan60);
            tableCellProperties84.Append(tableCellBorders84);
            tableCellProperties84.Append(shading84);

            Paragraph paragraph96 = new Paragraph() { RsidParagraphAddition = "00763846", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00763846" };

            ParagraphProperties paragraphProperties94 = new ParagraphProperties();
            Justification justification90 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties94.Append(justification90);

            paragraph96.Append(paragraphProperties94);

            tableCell84.Append(tableCellProperties84);
            tableCell84.Append(paragraph96);

            tableRow23.Append(tableCell84);

            table3.Append(tableProperties3);
            table3.Append(tableGrid3);
            table3.Append(tableRow15);
            table3.Append(tableRow16);
            table3.Append(tableRow17);
            table3.Append(tableRow18);
            table3.Append(tableRow19);
            table3.Append(tableRow20);
            table3.Append(tableRow21);
            table3.Append(tableRow22);
            table3.Append(tableRow23);

            Paragraph paragraph97 = new Paragraph() { RsidParagraphAddition = "004B288E", RsidParagraphProperties = "00EE02E1", RsidRunAdditionDefault = "00F0258F" };

            ParagraphProperties paragraphProperties95 = new ParagraphProperties();
            Indentation indentation16 = new Indentation() { FirstLine = "708" };
            Justification justification91 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties95.Append(indentation16);
            paragraphProperties95.Append(justification91);

            Run run66 = new Run();
            Text text66 = new Text();
            text66.Text = "Начальник военной кафедры";

            run66.Append(text66);

            paragraph97.Append(paragraphProperties95);
            paragraph97.Append(run66);

            Table table4 = new Table();

            TableProperties tableProperties4 = new TableProperties();
            TableWidth tableWidth4 = new TableWidth() { Width = "0", Type = TableWidthUnitValues.Auto };
            TableIndentation tableIndentation2 = new TableIndentation() { Width = 4248, Type = TableWidthUnitValues.Dxa };
            TableLook tableLook4 = new TableLook() { Val = "01E0", FirstRow = true, LastRow = true, FirstColumn = true, LastColumn = true, NoHorizontalBand = false, NoVerticalBand = false };

            tableProperties4.Append(tableWidth4);
            tableProperties4.Append(tableIndentation2);
            tableProperties4.Append(tableLook4);

            TableGrid tableGrid4 = new TableGrid();
            GridColumn gridColumn30 = new GridColumn() { Width = "1800" };
            GridColumn gridColumn31 = new GridColumn() { Width = "2700" };
            GridColumn gridColumn32 = new GridColumn() { Width = "2520" };

            tableGrid4.Append(gridColumn30);
            tableGrid4.Append(gridColumn31);
            tableGrid4.Append(gridColumn32);

            TableRow tableRow24 = new TableRow() { RsidTableRowAddition = "00F0258F", RsidTableRowProperties = "00E96696" };

            TableCell tableCell85 = new TableCell();

            TableCellProperties tableCellProperties85 = new TableCellProperties();
            TableCellWidth tableCellWidth85 = new TableCellWidth() { Width = "1800", Type = TableWidthUnitValues.Dxa };
            Shading shading85 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties85.Append(tableCellWidth85);
            tableCellProperties85.Append(shading85);

            Paragraph paragraph98 = new Paragraph() { RsidParagraphAddition = "00F0258F", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00F0258F" };

            ParagraphProperties paragraphProperties96 = new ParagraphProperties();
            Justification justification92 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties96.Append(justification92);

            Run run67 = new Run();
            Text text67 = new Text();
            text67.Text = "подполковник";

            run67.Append(text67);

            paragraph98.Append(paragraphProperties96);
            paragraph98.Append(run67);

            tableCell85.Append(tableCellProperties85);
            tableCell85.Append(paragraph98);

            TableCell tableCell86 = new TableCell();

            TableCellProperties tableCellProperties86 = new TableCellProperties();
            TableCellWidth tableCellWidth86 = new TableCellWidth() { Width = "2700", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders85 = new TableCellBorders();
            BottomBorder bottomBorder88 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders85.Append(bottomBorder88);
            Shading shading86 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties86.Append(tableCellWidth86);
            tableCellProperties86.Append(tableCellBorders85);
            tableCellProperties86.Append(shading86);

            Paragraph paragraph99 = new Paragraph() { RsidParagraphAddition = "00F0258F", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00F0258F" };

            ParagraphProperties paragraphProperties97 = new ParagraphProperties();
            Justification justification93 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties97.Append(justification93);

            paragraph99.Append(paragraphProperties97);

            tableCell86.Append(tableCellProperties86);
            tableCell86.Append(paragraph99);

            TableCell tableCell87 = new TableCell();

            TableCellProperties tableCellProperties87 = new TableCellProperties();
            TableCellWidth tableCellWidth87 = new TableCellWidth() { Width = "2520", Type = TableWidthUnitValues.Dxa };
            Shading shading87 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties87.Append(tableCellWidth87);
            tableCellProperties87.Append(shading87);

            Paragraph paragraph100 = new Paragraph() { RsidParagraphAddition = "00F0258F", RsidParagraphProperties = "00F0258F", RsidRunAdditionDefault = "00F0258F" };

            Run run68 = new Run();
            Text text68 = new Text();
            text68.Text = "А.";

            run68.Append(text68);

            Run run69 = new Run() { RsidRunProperties = "00E96696", RsidRunAddition = "00173B96" };

            RunProperties runProperties34 = new RunProperties();
            Languages languages41 = new Languages() { Val = "en-US" };

            runProperties34.Append(languages41);
            Text text69 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text69.Text = " ";

            run69.Append(runProperties34);
            run69.Append(text69);

            Run run70 = new Run();
            Text text70 = new Text();
            text70.Text = "Сагула";

            run70.Append(text70);

            paragraph100.Append(run68);
            paragraph100.Append(run69);
            paragraph100.Append(run70);

            tableCell87.Append(tableCellProperties87);
            tableCell87.Append(paragraph100);

            tableRow24.Append(tableCell85);
            tableRow24.Append(tableCell86);
            tableRow24.Append(tableCell87);

            table4.Append(tableProperties4);
            table4.Append(tableGrid4);
            table4.Append(tableRow24);

            Paragraph paragraph101 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "006E25E8", RsidRunAdditionDefault = "009F30D9" };

            Run run71 = new Run();
            Break break1 = new Break() { Type = BreakValues.Page };

            run71.Append(break1);

            paragraph101.Append(run71);

            Paragraph paragraph102 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "006E25E8", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties98 = new ParagraphProperties();
            Justification justification94 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties98.Append(justification94);

            Run run72 = new Run();
            Text text71 = new Text();
            text71.Text = "Успеваемость";

            run72.Append(text71);

            paragraph102.Append(paragraphProperties98);
            paragraph102.Append(run72);

            Table table5 = new Table();

            TableProperties tableProperties5 = new TableProperties();
            TableWidth tableWidth5 = new TableWidth() { Width = "0", Type = TableWidthUnitValues.Auto };
            TableJustification tableJustification1 = new TableJustification() { Val = TableRowAlignmentValues.Center };

            TableBorders tableBorders4 = new TableBorders();
            TopBorder topBorder83 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder74 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder89 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder74 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            InsideHorizontalBorder insideHorizontalBorder3 = new InsideHorizontalBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            InsideVerticalBorder insideVerticalBorder3 = new InsideVerticalBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableBorders4.Append(topBorder83);
            tableBorders4.Append(leftBorder74);
            tableBorders4.Append(bottomBorder89);
            tableBorders4.Append(rightBorder74);
            tableBorders4.Append(insideHorizontalBorder3);
            tableBorders4.Append(insideVerticalBorder3);
            TableLayout tableLayout2 = new TableLayout() { Type = TableLayoutValues.Fixed };
            TableLook tableLook5 = new TableLook() { Val = "01E0", FirstRow = true, LastRow = true, FirstColumn = true, LastColumn = true, NoHorizontalBand = false, NoVerticalBand = false };

            tableProperties5.Append(tableWidth5);
            tableProperties5.Append(tableJustification1);
            tableProperties5.Append(tableBorders4);
            tableProperties5.Append(tableLayout2);
            tableProperties5.Append(tableLook5);

            TableGrid tableGrid5 = new TableGrid();
            GridColumn gridColumn33 = new GridColumn() { Width = "2448" };
            GridColumn gridColumn34 = new GridColumn() { Width = "742" };
            GridColumn gridColumn35 = new GridColumn() { Width = "743" };
            GridColumn gridColumn36 = new GridColumn() { Width = "742" };
            GridColumn gridColumn37 = new GridColumn() { Width = "743" };
            GridColumn gridColumn38 = new GridColumn() { Width = "742" };
            GridColumn gridColumn39 = new GridColumn() { Width = "743" };
            GridColumn gridColumn40 = new GridColumn() { Width = "742" };
            GridColumn gridColumn41 = new GridColumn() { Width = "743" };
            GridColumn gridColumn42 = new GridColumn() { Width = "2340" };
            GridColumn gridColumn43 = new GridColumn() { Width = "2700" };

            tableGrid5.Append(gridColumn33);
            tableGrid5.Append(gridColumn34);
            tableGrid5.Append(gridColumn35);
            tableGrid5.Append(gridColumn36);
            tableGrid5.Append(gridColumn37);
            tableGrid5.Append(gridColumn38);
            tableGrid5.Append(gridColumn39);
            tableGrid5.Append(gridColumn40);
            tableGrid5.Append(gridColumn41);
            tableGrid5.Append(gridColumn42);
            tableGrid5.Append(gridColumn43);

            TableRow tableRow25 = new TableRow() { RsidTableRowMarkRevision = "00E96696", RsidTableRowAddition = "006E25E8", RsidTableRowProperties = "00E96696" };

            TableRowProperties tableRowProperties4 = new TableRowProperties();
            TableJustification tableJustification2 = new TableJustification() { Val = TableRowAlignmentValues.Center };

            tableRowProperties4.Append(tableJustification2);

            TableCell tableCell88 = new TableCell();

            TableCellProperties tableCellProperties88 = new TableCellProperties();
            TableCellWidth tableCellWidth88 = new TableCellWidth() { Width = "2448", Type = TableWidthUnitValues.Dxa };
            VerticalMerge verticalMerge1 = new VerticalMerge() { Val = MergedCellValues.Restart };

            TableCellBorders tableCellBorders86 = new TableCellBorders();
            TopBorder topBorder84 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder75 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder90 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder75 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders86.Append(topBorder84);
            tableCellBorders86.Append(leftBorder75);
            tableCellBorders86.Append(bottomBorder90);
            tableCellBorders86.Append(rightBorder75);
            Shading shading88 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            HideMark hideMark1 = new HideMark();

            tableCellProperties88.Append(tableCellWidth88);
            tableCellProperties88.Append(verticalMerge1);
            tableCellProperties88.Append(tableCellBorders86);
            tableCellProperties88.Append(shading88);
            tableCellProperties88.Append(hideMark1);

            Paragraph paragraph103 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties99 = new ParagraphProperties();
            Justification justification95 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties99.Append(justification95);

            Run run73 = new Run();
            Text text72 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text72.Text = "Наименование дисциплины обучения ";

            run73.Append(text72);

            paragraph103.Append(paragraphProperties99);
            paragraph103.Append(run73);

            Paragraph paragraph104 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties100 = new ParagraphProperties();
            Justification justification96 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties100.Append(justification96);

            Run run74 = new Run();
            Text text73 = new Text();
            text73.Text = "и учебных сборов";

            run74.Append(text73);

            paragraph104.Append(paragraphProperties100);
            paragraph104.Append(run74);

            tableCell88.Append(tableCellProperties88);
            tableCell88.Append(paragraph103);
            tableCell88.Append(paragraph104);

            TableCell tableCell89 = new TableCell();

            TableCellProperties tableCellProperties89 = new TableCellProperties();
            TableCellWidth tableCellWidth89 = new TableCellWidth() { Width = "5940", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan61 = new GridSpan() { Val = 8 };

            TableCellBorders tableCellBorders87 = new TableCellBorders();
            TopBorder topBorder85 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder76 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder91 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder76 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders87.Append(topBorder85);
            tableCellBorders87.Append(leftBorder76);
            tableCellBorders87.Append(bottomBorder91);
            tableCellBorders87.Append(rightBorder76);
            Shading shading89 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            HideMark hideMark2 = new HideMark();

            tableCellProperties89.Append(tableCellWidth89);
            tableCellProperties89.Append(gridSpan61);
            tableCellProperties89.Append(tableCellBorders87);
            tableCellProperties89.Append(shading89);
            tableCellProperties89.Append(hideMark2);

            Paragraph paragraph105 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties101 = new ParagraphProperties();
            Justification justification97 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties101.Append(justification97);

            Run run75 = new Run();
            Text text74 = new Text();
            text74.Text = "Семестры";

            run75.Append(text74);

            paragraph105.Append(paragraphProperties101);
            paragraph105.Append(run75);

            tableCell89.Append(tableCellProperties89);
            tableCell89.Append(paragraph105);

            TableCell tableCell90 = new TableCell();

            TableCellProperties tableCellProperties90 = new TableCellProperties();
            TableCellWidth tableCellWidth90 = new TableCellWidth() { Width = "2340", Type = TableWidthUnitValues.Dxa };
            VerticalMerge verticalMerge2 = new VerticalMerge() { Val = MergedCellValues.Restart };

            TableCellBorders tableCellBorders88 = new TableCellBorders();
            TopBorder topBorder86 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder77 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder92 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder77 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders88.Append(topBorder86);
            tableCellBorders88.Append(leftBorder77);
            tableCellBorders88.Append(bottomBorder92);
            tableCellBorders88.Append(rightBorder77);
            Shading shading90 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            TableCellVerticalAlignment tableCellVerticalAlignment1 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };
            HideMark hideMark3 = new HideMark();

            tableCellProperties90.Append(tableCellWidth90);
            tableCellProperties90.Append(verticalMerge2);
            tableCellProperties90.Append(tableCellBorders88);
            tableCellProperties90.Append(shading90);
            tableCellProperties90.Append(tableCellVerticalAlignment1);
            tableCellProperties90.Append(hideMark3);

            Paragraph paragraph106 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties102 = new ParagraphProperties();
            Justification justification98 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties102.Append(justification98);

            Run run76 = new Run();
            Text text75 = new Text();
            text75.Text = "Государственный";

            run76.Append(text75);

            paragraph106.Append(paragraphProperties102);
            paragraph106.Append(run76);

            Paragraph paragraph107 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties103 = new ParagraphProperties();
            Justification justification99 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties103.Append(justification99);

            Run run77 = new Run();
            Text text76 = new Text();
            text76.Text = "выпускной";

            run77.Append(text76);

            paragraph107.Append(paragraphProperties103);
            paragraph107.Append(run77);

            Paragraph paragraph108 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties104 = new ParagraphProperties();
            Justification justification100 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties104.Append(justification100);

            Run run78 = new Run();
            Text text77 = new Text();
            text77.Text = "экзамен";

            run78.Append(text77);

            paragraph108.Append(paragraphProperties104);
            paragraph108.Append(run78);

            tableCell90.Append(tableCellProperties90);
            tableCell90.Append(paragraph106);
            tableCell90.Append(paragraph107);
            tableCell90.Append(paragraph108);

            TableCell tableCell91 = new TableCell();

            TableCellProperties tableCellProperties91 = new TableCellProperties();
            TableCellWidth tableCellWidth91 = new TableCellWidth() { Width = "2700", Type = TableWidthUnitValues.Dxa };
            VerticalMerge verticalMerge3 = new VerticalMerge() { Val = MergedCellValues.Restart };

            TableCellBorders tableCellBorders89 = new TableCellBorders();
            TopBorder topBorder87 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder78 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder93 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder78 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders89.Append(topBorder87);
            tableCellBorders89.Append(leftBorder78);
            tableCellBorders89.Append(bottomBorder93);
            tableCellBorders89.Append(rightBorder78);
            Shading shading91 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            TableCellVerticalAlignment tableCellVerticalAlignment2 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };
            HideMark hideMark4 = new HideMark();

            tableCellProperties91.Append(tableCellWidth91);
            tableCellProperties91.Append(verticalMerge3);
            tableCellProperties91.Append(tableCellBorders89);
            tableCellProperties91.Append(shading91);
            tableCellProperties91.Append(tableCellVerticalAlignment2);
            tableCellProperties91.Append(hideMark4);

            Paragraph paragraph109 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties105 = new ParagraphProperties();
            Justification justification101 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties105.Append(justification101);

            Run run79 = new Run();
            Text text78 = new Text();
            text78.Text = "Примечание";

            run79.Append(text78);

            paragraph109.Append(paragraphProperties105);
            paragraph109.Append(run79);

            tableCell91.Append(tableCellProperties91);
            tableCell91.Append(paragraph109);

            tableRow25.Append(tableRowProperties4);
            tableRow25.Append(tableCell88);
            tableRow25.Append(tableCell89);
            tableRow25.Append(tableCell90);
            tableRow25.Append(tableCell91);

            TableRow tableRow26 = new TableRow() { RsidTableRowMarkRevision = "00E96696", RsidTableRowAddition = "006E25E8", RsidTableRowProperties = "00E96696" };

            TableRowProperties tableRowProperties5 = new TableRowProperties();
            TableJustification tableJustification3 = new TableJustification() { Val = TableRowAlignmentValues.Center };

            tableRowProperties5.Append(tableJustification3);

            TableCell tableCell92 = new TableCell();

            TableCellProperties tableCellProperties92 = new TableCellProperties();
            TableCellWidth tableCellWidth92 = new TableCellWidth() { Width = "2448", Type = TableWidthUnitValues.Dxa };
            VerticalMerge verticalMerge4 = new VerticalMerge();

            TableCellBorders tableCellBorders90 = new TableCellBorders();
            TopBorder topBorder88 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder79 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder94 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder79 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders90.Append(topBorder88);
            tableCellBorders90.Append(leftBorder79);
            tableCellBorders90.Append(bottomBorder94);
            tableCellBorders90.Append(rightBorder79);
            Shading shading92 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            TableCellVerticalAlignment tableCellVerticalAlignment3 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };
            HideMark hideMark5 = new HideMark();

            tableCellProperties92.Append(tableCellWidth92);
            tableCellProperties92.Append(verticalMerge4);
            tableCellProperties92.Append(tableCellBorders90);
            tableCellProperties92.Append(shading92);
            tableCellProperties92.Append(tableCellVerticalAlignment3);
            tableCellProperties92.Append(hideMark5);
            Paragraph paragraph110 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidRunAdditionDefault = "006E25E8" };

            tableCell92.Append(tableCellProperties92);
            tableCell92.Append(paragraph110);

            TableCell tableCell93 = new TableCell();

            TableCellProperties tableCellProperties93 = new TableCellProperties();
            TableCellWidth tableCellWidth93 = new TableCellWidth() { Width = "742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders91 = new TableCellBorders();
            TopBorder topBorder89 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder80 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder95 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder80 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders91.Append(topBorder89);
            tableCellBorders91.Append(leftBorder80);
            tableCellBorders91.Append(bottomBorder95);
            tableCellBorders91.Append(rightBorder80);
            Shading shading93 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            TableCellVerticalAlignment tableCellVerticalAlignment4 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };
            HideMark hideMark6 = new HideMark();

            tableCellProperties93.Append(tableCellWidth93);
            tableCellProperties93.Append(tableCellBorders91);
            tableCellProperties93.Append(shading93);
            tableCellProperties93.Append(tableCellVerticalAlignment4);
            tableCellProperties93.Append(hideMark6);

            Paragraph paragraph111 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties106 = new ParagraphProperties();
            Justification justification102 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties106.Append(justification102);

            Run run80 = new Run();
            Text text79 = new Text();
            text79.Text = "3";

            run80.Append(text79);

            paragraph111.Append(paragraphProperties106);
            paragraph111.Append(run80);

            tableCell93.Append(tableCellProperties93);
            tableCell93.Append(paragraph111);

            TableCell tableCell94 = new TableCell();

            TableCellProperties tableCellProperties94 = new TableCellProperties();
            TableCellWidth tableCellWidth94 = new TableCellWidth() { Width = "743", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders92 = new TableCellBorders();
            TopBorder topBorder90 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder81 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder96 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder81 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders92.Append(topBorder90);
            tableCellBorders92.Append(leftBorder81);
            tableCellBorders92.Append(bottomBorder96);
            tableCellBorders92.Append(rightBorder81);
            Shading shading94 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            TableCellVerticalAlignment tableCellVerticalAlignment5 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };
            HideMark hideMark7 = new HideMark();

            tableCellProperties94.Append(tableCellWidth94);
            tableCellProperties94.Append(tableCellBorders92);
            tableCellProperties94.Append(shading94);
            tableCellProperties94.Append(tableCellVerticalAlignment5);
            tableCellProperties94.Append(hideMark7);

            Paragraph paragraph112 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties107 = new ParagraphProperties();
            Justification justification103 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties107.Append(justification103);

            Run run81 = new Run();
            Text text80 = new Text();
            text80.Text = "4";

            run81.Append(text80);

            paragraph112.Append(paragraphProperties107);
            paragraph112.Append(run81);

            tableCell94.Append(tableCellProperties94);
            tableCell94.Append(paragraph112);

            TableCell tableCell95 = new TableCell();

            TableCellProperties tableCellProperties95 = new TableCellProperties();
            TableCellWidth tableCellWidth95 = new TableCellWidth() { Width = "742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders93 = new TableCellBorders();
            TopBorder topBorder91 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder82 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder97 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder82 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders93.Append(topBorder91);
            tableCellBorders93.Append(leftBorder82);
            tableCellBorders93.Append(bottomBorder97);
            tableCellBorders93.Append(rightBorder82);
            Shading shading95 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            TableCellVerticalAlignment tableCellVerticalAlignment6 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };
            HideMark hideMark8 = new HideMark();

            tableCellProperties95.Append(tableCellWidth95);
            tableCellProperties95.Append(tableCellBorders93);
            tableCellProperties95.Append(shading95);
            tableCellProperties95.Append(tableCellVerticalAlignment6);
            tableCellProperties95.Append(hideMark8);

            Paragraph paragraph113 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties108 = new ParagraphProperties();
            Justification justification104 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties108.Append(justification104);

            Run run82 = new Run();
            Text text81 = new Text();
            text81.Text = "5";

            run82.Append(text81);

            paragraph113.Append(paragraphProperties108);
            paragraph113.Append(run82);

            tableCell95.Append(tableCellProperties95);
            tableCell95.Append(paragraph113);

            TableCell tableCell96 = new TableCell();

            TableCellProperties tableCellProperties96 = new TableCellProperties();
            TableCellWidth tableCellWidth96 = new TableCellWidth() { Width = "743", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders94 = new TableCellBorders();
            TopBorder topBorder92 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder83 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder98 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder83 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders94.Append(topBorder92);
            tableCellBorders94.Append(leftBorder83);
            tableCellBorders94.Append(bottomBorder98);
            tableCellBorders94.Append(rightBorder83);
            Shading shading96 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            TableCellVerticalAlignment tableCellVerticalAlignment7 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };
            HideMark hideMark9 = new HideMark();

            tableCellProperties96.Append(tableCellWidth96);
            tableCellProperties96.Append(tableCellBorders94);
            tableCellProperties96.Append(shading96);
            tableCellProperties96.Append(tableCellVerticalAlignment7);
            tableCellProperties96.Append(hideMark9);

            Paragraph paragraph114 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties109 = new ParagraphProperties();
            Justification justification105 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties109.Append(justification105);

            Run run83 = new Run();
            Text text82 = new Text();
            text82.Text = "6";

            run83.Append(text82);

            paragraph114.Append(paragraphProperties109);
            paragraph114.Append(run83);

            tableCell96.Append(tableCellProperties96);
            tableCell96.Append(paragraph114);

            TableCell tableCell97 = new TableCell();

            TableCellProperties tableCellProperties97 = new TableCellProperties();
            TableCellWidth tableCellWidth97 = new TableCellWidth() { Width = "742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders95 = new TableCellBorders();
            TopBorder topBorder93 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder84 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder99 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder84 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders95.Append(topBorder93);
            tableCellBorders95.Append(leftBorder84);
            tableCellBorders95.Append(bottomBorder99);
            tableCellBorders95.Append(rightBorder84);
            Shading shading97 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            TableCellVerticalAlignment tableCellVerticalAlignment8 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };
            HideMark hideMark10 = new HideMark();

            tableCellProperties97.Append(tableCellWidth97);
            tableCellProperties97.Append(tableCellBorders95);
            tableCellProperties97.Append(shading97);
            tableCellProperties97.Append(tableCellVerticalAlignment8);
            tableCellProperties97.Append(hideMark10);

            Paragraph paragraph115 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties110 = new ParagraphProperties();
            Justification justification106 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties110.Append(justification106);

            Run run84 = new Run();
            Text text83 = new Text();
            text83.Text = "7";

            run84.Append(text83);

            paragraph115.Append(paragraphProperties110);
            paragraph115.Append(run84);

            tableCell97.Append(tableCellProperties97);
            tableCell97.Append(paragraph115);

            TableCell tableCell98 = new TableCell();

            TableCellProperties tableCellProperties98 = new TableCellProperties();
            TableCellWidth tableCellWidth98 = new TableCellWidth() { Width = "743", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders96 = new TableCellBorders();
            TopBorder topBorder94 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder85 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder100 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder85 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders96.Append(topBorder94);
            tableCellBorders96.Append(leftBorder85);
            tableCellBorders96.Append(bottomBorder100);
            tableCellBorders96.Append(rightBorder85);
            Shading shading98 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            TableCellVerticalAlignment tableCellVerticalAlignment9 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };
            HideMark hideMark11 = new HideMark();

            tableCellProperties98.Append(tableCellWidth98);
            tableCellProperties98.Append(tableCellBorders96);
            tableCellProperties98.Append(shading98);
            tableCellProperties98.Append(tableCellVerticalAlignment9);
            tableCellProperties98.Append(hideMark11);

            Paragraph paragraph116 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties111 = new ParagraphProperties();
            Justification justification107 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties111.Append(justification107);

            Run run85 = new Run();
            Text text84 = new Text();
            text84.Text = "8";

            run85.Append(text84);

            paragraph116.Append(paragraphProperties111);
            paragraph116.Append(run85);

            tableCell98.Append(tableCellProperties98);
            tableCell98.Append(paragraph116);

            TableCell tableCell99 = new TableCell();

            TableCellProperties tableCellProperties99 = new TableCellProperties();
            TableCellWidth tableCellWidth99 = new TableCellWidth() { Width = "742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders97 = new TableCellBorders();
            TopBorder topBorder95 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder86 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder101 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder86 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders97.Append(topBorder95);
            tableCellBorders97.Append(leftBorder86);
            tableCellBorders97.Append(bottomBorder101);
            tableCellBorders97.Append(rightBorder86);
            Shading shading99 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            TableCellVerticalAlignment tableCellVerticalAlignment10 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };
            HideMark hideMark12 = new HideMark();

            tableCellProperties99.Append(tableCellWidth99);
            tableCellProperties99.Append(tableCellBorders97);
            tableCellProperties99.Append(shading99);
            tableCellProperties99.Append(tableCellVerticalAlignment10);
            tableCellProperties99.Append(hideMark12);

            Paragraph paragraph117 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties112 = new ParagraphProperties();
            Justification justification108 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties112.Append(justification108);

            Run run86 = new Run();
            Text text85 = new Text();
            text85.Text = "9";

            run86.Append(text85);

            paragraph117.Append(paragraphProperties112);
            paragraph117.Append(run86);

            tableCell99.Append(tableCellProperties99);
            tableCell99.Append(paragraph117);

            TableCell tableCell100 = new TableCell();

            TableCellProperties tableCellProperties100 = new TableCellProperties();
            TableCellWidth tableCellWidth100 = new TableCellWidth() { Width = "743", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders98 = new TableCellBorders();
            TopBorder topBorder96 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder87 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder102 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder87 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders98.Append(topBorder96);
            tableCellBorders98.Append(leftBorder87);
            tableCellBorders98.Append(bottomBorder102);
            tableCellBorders98.Append(rightBorder87);
            Shading shading100 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            TableCellVerticalAlignment tableCellVerticalAlignment11 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };
            HideMark hideMark13 = new HideMark();

            tableCellProperties100.Append(tableCellWidth100);
            tableCellProperties100.Append(tableCellBorders98);
            tableCellProperties100.Append(shading100);
            tableCellProperties100.Append(tableCellVerticalAlignment11);
            tableCellProperties100.Append(hideMark13);

            Paragraph paragraph118 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties113 = new ParagraphProperties();
            Justification justification109 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties113.Append(justification109);

            Run run87 = new Run();
            Text text86 = new Text();
            text86.Text = "10";

            run87.Append(text86);

            paragraph118.Append(paragraphProperties113);
            paragraph118.Append(run87);

            tableCell100.Append(tableCellProperties100);
            tableCell100.Append(paragraph118);

            TableCell tableCell101 = new TableCell();

            TableCellProperties tableCellProperties101 = new TableCellProperties();
            TableCellWidth tableCellWidth101 = new TableCellWidth() { Width = "2340", Type = TableWidthUnitValues.Dxa };
            VerticalMerge verticalMerge5 = new VerticalMerge();

            TableCellBorders tableCellBorders99 = new TableCellBorders();
            TopBorder topBorder97 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder88 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder103 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder88 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders99.Append(topBorder97);
            tableCellBorders99.Append(leftBorder88);
            tableCellBorders99.Append(bottomBorder103);
            tableCellBorders99.Append(rightBorder88);
            Shading shading101 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            TableCellVerticalAlignment tableCellVerticalAlignment12 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };
            HideMark hideMark14 = new HideMark();

            tableCellProperties101.Append(tableCellWidth101);
            tableCellProperties101.Append(verticalMerge5);
            tableCellProperties101.Append(tableCellBorders99);
            tableCellProperties101.Append(shading101);
            tableCellProperties101.Append(tableCellVerticalAlignment12);
            tableCellProperties101.Append(hideMark14);
            Paragraph paragraph119 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidRunAdditionDefault = "006E25E8" };

            tableCell101.Append(tableCellProperties101);
            tableCell101.Append(paragraph119);

            TableCell tableCell102 = new TableCell();

            TableCellProperties tableCellProperties102 = new TableCellProperties();
            TableCellWidth tableCellWidth102 = new TableCellWidth() { Width = "2700", Type = TableWidthUnitValues.Dxa };
            VerticalMerge verticalMerge6 = new VerticalMerge();

            TableCellBorders tableCellBorders100 = new TableCellBorders();
            TopBorder topBorder98 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder89 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder104 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder89 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders100.Append(topBorder98);
            tableCellBorders100.Append(leftBorder89);
            tableCellBorders100.Append(bottomBorder104);
            tableCellBorders100.Append(rightBorder89);
            Shading shading102 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            TableCellVerticalAlignment tableCellVerticalAlignment13 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };
            HideMark hideMark15 = new HideMark();

            tableCellProperties102.Append(tableCellWidth102);
            tableCellProperties102.Append(verticalMerge6);
            tableCellProperties102.Append(tableCellBorders100);
            tableCellProperties102.Append(shading102);
            tableCellProperties102.Append(tableCellVerticalAlignment13);
            tableCellProperties102.Append(hideMark15);
            Paragraph paragraph120 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidRunAdditionDefault = "006E25E8" };

            tableCell102.Append(tableCellProperties102);
            tableCell102.Append(paragraph120);

            tableRow26.Append(tableRowProperties5);
            tableRow26.Append(tableCell92);
            tableRow26.Append(tableCell93);
            tableRow26.Append(tableCell94);
            tableRow26.Append(tableCell95);
            tableRow26.Append(tableCell96);
            tableRow26.Append(tableCell97);
            tableRow26.Append(tableCell98);
            tableRow26.Append(tableCell99);
            tableRow26.Append(tableCell100);
            tableRow26.Append(tableCell101);
            tableRow26.Append(tableCell102);

            TableRow tableRow27 = new TableRow() { RsidTableRowMarkRevision = "00E96696", RsidTableRowAddition = "006E25E8", RsidTableRowProperties = "00E96696" };

            TableRowProperties tableRowProperties6 = new TableRowProperties();
            TableJustification tableJustification4 = new TableJustification() { Val = TableRowAlignmentValues.Center };

            tableRowProperties6.Append(tableJustification4);

            TableCell tableCell103 = new TableCell();

            TableCellProperties tableCellProperties103 = new TableCellProperties();
            TableCellWidth tableCellWidth103 = new TableCellWidth() { Width = "2448", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders101 = new TableCellBorders();
            TopBorder topBorder99 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder90 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder105 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder90 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders101.Append(topBorder99);
            tableCellBorders101.Append(leftBorder90);
            tableCellBorders101.Append(bottomBorder105);
            tableCellBorders101.Append(rightBorder90);
            Shading shading103 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            HideMark hideMark16 = new HideMark();

            tableCellProperties103.Append(tableCellWidth103);
            tableCellProperties103.Append(tableCellBorders101);
            tableCellProperties103.Append(shading103);
            tableCellProperties103.Append(hideMark16);

            Paragraph paragraph121 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties114 = new ParagraphProperties();
            Justification justification110 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties114.Append(justification110);

            Run run88 = new Run();
            Text text87 = new Text();
            text87.Text = "ОВП(зачёт)";

            run88.Append(text87);

            paragraph121.Append(paragraphProperties114);
            paragraph121.Append(run88);

            tableCell103.Append(tableCellProperties103);
            tableCell103.Append(paragraph121);

            TableCell tableCell104 = new TableCell();

            TableCellProperties tableCellProperties104 = new TableCellProperties();
            TableCellWidth tableCellWidth104 = new TableCellWidth() { Width = "742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders102 = new TableCellBorders();
            TopBorder topBorder100 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder91 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder106 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder91 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders102.Append(topBorder100);
            tableCellBorders102.Append(leftBorder91);
            tableCellBorders102.Append(bottomBorder106);
            tableCellBorders102.Append(rightBorder91);
            Shading shading104 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties104.Append(tableCellWidth104);
            tableCellProperties104.Append(tableCellBorders102);
            tableCellProperties104.Append(shading104);

            Paragraph paragraph122 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties115 = new ParagraphProperties();
            Justification justification111 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties115.Append(justification111);

            paragraph122.Append(paragraphProperties115);

            tableCell104.Append(tableCellProperties104);
            tableCell104.Append(paragraph122);

            TableCell tableCell105 = new TableCell();

            TableCellProperties tableCellProperties105 = new TableCellProperties();
            TableCellWidth tableCellWidth105 = new TableCellWidth() { Width = "743", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders103 = new TableCellBorders();
            TopBorder topBorder101 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder92 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder107 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder92 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders103.Append(topBorder101);
            tableCellBorders103.Append(leftBorder92);
            tableCellBorders103.Append(bottomBorder107);
            tableCellBorders103.Append(rightBorder92);
            Shading shading105 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties105.Append(tableCellWidth105);
            tableCellProperties105.Append(tableCellBorders103);
            tableCellProperties105.Append(shading105);

            Paragraph paragraph123 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties116 = new ParagraphProperties();
            Justification justification112 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties116.Append(justification112);

            paragraph123.Append(paragraphProperties116);

            tableCell105.Append(tableCellProperties105);
            tableCell105.Append(paragraph123);

            TableCell tableCell106 = new TableCell();

            TableCellProperties tableCellProperties106 = new TableCellProperties();
            TableCellWidth tableCellWidth106 = new TableCellWidth() { Width = "742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders104 = new TableCellBorders();
            TopBorder topBorder102 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder93 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder108 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder93 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders104.Append(topBorder102);
            tableCellBorders104.Append(leftBorder93);
            tableCellBorders104.Append(bottomBorder108);
            tableCellBorders104.Append(rightBorder93);
            Shading shading106 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties106.Append(tableCellWidth106);
            tableCellProperties106.Append(tableCellBorders104);
            tableCellProperties106.Append(shading106);

            Paragraph paragraph124 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties117 = new ParagraphProperties();
            Justification justification113 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties117.Append(justification113);

            paragraph124.Append(paragraphProperties117);

            tableCell106.Append(tableCellProperties106);
            tableCell106.Append(paragraph124);

            TableCell tableCell107 = new TableCell();

            TableCellProperties tableCellProperties107 = new TableCellProperties();
            TableCellWidth tableCellWidth107 = new TableCellWidth() { Width = "743", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders105 = new TableCellBorders();
            TopBorder topBorder103 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder94 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder109 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder94 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders105.Append(topBorder103);
            tableCellBorders105.Append(leftBorder94);
            tableCellBorders105.Append(bottomBorder109);
            tableCellBorders105.Append(rightBorder94);
            Shading shading107 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties107.Append(tableCellWidth107);
            tableCellProperties107.Append(tableCellBorders105);
            tableCellProperties107.Append(shading107);

            Paragraph paragraph125 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties118 = new ParagraphProperties();
            Justification justification114 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties118.Append(justification114);

            paragraph125.Append(paragraphProperties118);

            tableCell107.Append(tableCellProperties107);
            tableCell107.Append(paragraph125);

            TableCell tableCell108 = new TableCell();

            TableCellProperties tableCellProperties108 = new TableCellProperties();
            TableCellWidth tableCellWidth108 = new TableCellWidth() { Width = "742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders106 = new TableCellBorders();
            TopBorder topBorder104 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder95 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder110 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder95 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders106.Append(topBorder104);
            tableCellBorders106.Append(leftBorder95);
            tableCellBorders106.Append(bottomBorder110);
            tableCellBorders106.Append(rightBorder95);
            Shading shading108 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties108.Append(tableCellWidth108);
            tableCellProperties108.Append(tableCellBorders106);
            tableCellProperties108.Append(shading108);

            Paragraph paragraph126 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties119 = new ParagraphProperties();
            Justification justification115 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties119.Append(justification115);

            paragraph126.Append(paragraphProperties119);

            tableCell108.Append(tableCellProperties108);
            tableCell108.Append(paragraph126);

            TableCell tableCell109 = new TableCell();

            TableCellProperties tableCellProperties109 = new TableCellProperties();
            TableCellWidth tableCellWidth109 = new TableCellWidth() { Width = "743", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders107 = new TableCellBorders();
            TopBorder topBorder105 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder96 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder111 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder96 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders107.Append(topBorder105);
            tableCellBorders107.Append(leftBorder96);
            tableCellBorders107.Append(bottomBorder111);
            tableCellBorders107.Append(rightBorder96);
            Shading shading109 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties109.Append(tableCellWidth109);
            tableCellProperties109.Append(tableCellBorders107);
            tableCellProperties109.Append(shading109);

            Paragraph paragraph127 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties120 = new ParagraphProperties();
            Justification justification116 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties120.Append(justification116);

            paragraph127.Append(paragraphProperties120);

            tableCell109.Append(tableCellProperties109);
            tableCell109.Append(paragraph127);

            TableCell tableCell110 = new TableCell();

            TableCellProperties tableCellProperties110 = new TableCellProperties();
            TableCellWidth tableCellWidth110 = new TableCellWidth() { Width = "742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders108 = new TableCellBorders();
            TopBorder topBorder106 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder97 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder112 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder97 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders108.Append(topBorder106);
            tableCellBorders108.Append(leftBorder97);
            tableCellBorders108.Append(bottomBorder112);
            tableCellBorders108.Append(rightBorder97);
            Shading shading110 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties110.Append(tableCellWidth110);
            tableCellProperties110.Append(tableCellBorders108);
            tableCellProperties110.Append(shading110);

            Paragraph paragraph128 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties121 = new ParagraphProperties();
            Justification justification117 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties121.Append(justification117);

            paragraph128.Append(paragraphProperties121);

            tableCell110.Append(tableCellProperties110);
            tableCell110.Append(paragraph128);

            TableCell tableCell111 = new TableCell();

            TableCellProperties tableCellProperties111 = new TableCellProperties();
            TableCellWidth tableCellWidth111 = new TableCellWidth() { Width = "743", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders109 = new TableCellBorders();
            TopBorder topBorder107 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder98 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder113 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder98 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders109.Append(topBorder107);
            tableCellBorders109.Append(leftBorder98);
            tableCellBorders109.Append(bottomBorder113);
            tableCellBorders109.Append(rightBorder98);
            Shading shading111 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties111.Append(tableCellWidth111);
            tableCellProperties111.Append(tableCellBorders109);
            tableCellProperties111.Append(shading111);

            Paragraph paragraph129 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties122 = new ParagraphProperties();
            Justification justification118 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties122.Append(justification118);

            paragraph129.Append(paragraphProperties122);

            tableCell111.Append(tableCellProperties111);
            tableCell111.Append(paragraph129);

            TableCell tableCell112 = new TableCell();

            TableCellProperties tableCellProperties112 = new TableCellProperties();
            TableCellWidth tableCellWidth112 = new TableCellWidth() { Width = "2340", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders110 = new TableCellBorders();
            TopBorder topBorder108 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder99 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder114 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder99 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders110.Append(topBorder108);
            tableCellBorders110.Append(leftBorder99);
            tableCellBorders110.Append(bottomBorder114);
            tableCellBorders110.Append(rightBorder99);
            Shading shading112 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties112.Append(tableCellWidth112);
            tableCellProperties112.Append(tableCellBorders110);
            tableCellProperties112.Append(shading112);

            Paragraph paragraph130 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties123 = new ParagraphProperties();
            Justification justification119 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties123.Append(justification119);

            paragraph130.Append(paragraphProperties123);

            tableCell112.Append(tableCellProperties112);
            tableCell112.Append(paragraph130);

            TableCell tableCell113 = new TableCell();

            TableCellProperties tableCellProperties113 = new TableCellProperties();
            TableCellWidth tableCellWidth113 = new TableCellWidth() { Width = "2700", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders111 = new TableCellBorders();
            TopBorder topBorder109 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder100 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder115 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder100 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders111.Append(topBorder109);
            tableCellBorders111.Append(leftBorder100);
            tableCellBorders111.Append(bottomBorder115);
            tableCellBorders111.Append(rightBorder100);
            Shading shading113 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties113.Append(tableCellWidth113);
            tableCellProperties113.Append(tableCellBorders111);
            tableCellProperties113.Append(shading113);

            Paragraph paragraph131 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties124 = new ParagraphProperties();
            Justification justification120 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties124.Append(justification120);

            paragraph131.Append(paragraphProperties124);

            tableCell113.Append(tableCellProperties113);
            tableCell113.Append(paragraph131);

            tableRow27.Append(tableRowProperties6);
            tableRow27.Append(tableCell103);
            tableRow27.Append(tableCell104);
            tableRow27.Append(tableCell105);
            tableRow27.Append(tableCell106);
            tableRow27.Append(tableCell107);
            tableRow27.Append(tableCell108);
            tableRow27.Append(tableCell109);
            tableRow27.Append(tableCell110);
            tableRow27.Append(tableCell111);
            tableRow27.Append(tableCell112);
            tableRow27.Append(tableCell113);

            TableRow tableRow28 = new TableRow() { RsidTableRowMarkRevision = "00E96696", RsidTableRowAddition = "00284D9B", RsidTableRowProperties = "00E96696" };

            TableRowProperties tableRowProperties7 = new TableRowProperties();
            TableJustification tableJustification5 = new TableJustification() { Val = TableRowAlignmentValues.Center };

            tableRowProperties7.Append(tableJustification5);

            TableCell tableCell114 = new TableCell();

            TableCellProperties tableCellProperties114 = new TableCellProperties();
            TableCellWidth tableCellWidth114 = new TableCellWidth() { Width = "2448", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders112 = new TableCellBorders();
            TopBorder topBorder110 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder101 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder116 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder101 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders112.Append(topBorder110);
            tableCellBorders112.Append(leftBorder101);
            tableCellBorders112.Append(bottomBorder116);
            tableCellBorders112.Append(rightBorder101);
            Shading shading114 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            HideMark hideMark17 = new HideMark();

            tableCellProperties114.Append(tableCellWidth114);
            tableCellProperties114.Append(tableCellBorders112);
            tableCellProperties114.Append(shading114);
            tableCellProperties114.Append(hideMark17);

            Paragraph paragraph132 = new Paragraph() { RsidParagraphAddition = "00284D9B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D9B" };

            ParagraphProperties paragraphProperties125 = new ParagraphProperties();
            Justification justification121 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties125.Append(justification121);

            Run run89 = new Run();
            Text text88 = new Text();
            text88.Text = "ОТ(зачёт)";

            run89.Append(text88);

            paragraph132.Append(paragraphProperties125);
            paragraph132.Append(run89);

            tableCell114.Append(tableCellProperties114);
            tableCell114.Append(paragraph132);

            TableCell tableCell115 = new TableCell();

            TableCellProperties tableCellProperties115 = new TableCellProperties();
            TableCellWidth tableCellWidth115 = new TableCellWidth() { Width = "742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders113 = new TableCellBorders();
            TopBorder topBorder111 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder102 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder117 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder102 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders113.Append(topBorder111);
            tableCellBorders113.Append(leftBorder102);
            tableCellBorders113.Append(bottomBorder117);
            tableCellBorders113.Append(rightBorder102);
            Shading shading115 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties115.Append(tableCellWidth115);
            tableCellProperties115.Append(tableCellBorders113);
            tableCellProperties115.Append(shading115);

            Paragraph paragraph133 = new Paragraph() { RsidParagraphAddition = "00284D9B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D9B" };

            ParagraphProperties paragraphProperties126 = new ParagraphProperties();
            Justification justification122 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties126.Append(justification122);

            paragraph133.Append(paragraphProperties126);

            tableCell115.Append(tableCellProperties115);
            tableCell115.Append(paragraph133);

            TableCell tableCell116 = new TableCell();

            TableCellProperties tableCellProperties116 = new TableCellProperties();
            TableCellWidth tableCellWidth116 = new TableCellWidth() { Width = "743", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders114 = new TableCellBorders();
            TopBorder topBorder112 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder103 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder118 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder103 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders114.Append(topBorder112);
            tableCellBorders114.Append(leftBorder103);
            tableCellBorders114.Append(bottomBorder118);
            tableCellBorders114.Append(rightBorder103);
            Shading shading116 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties116.Append(tableCellWidth116);
            tableCellProperties116.Append(tableCellBorders114);
            tableCellProperties116.Append(shading116);

            Paragraph paragraph134 = new Paragraph() { RsidParagraphAddition = "00284D9B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D9B" };

            ParagraphProperties paragraphProperties127 = new ParagraphProperties();
            Justification justification123 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties127.Append(justification123);

            paragraph134.Append(paragraphProperties127);

            tableCell116.Append(tableCellProperties116);
            tableCell116.Append(paragraph134);

            TableCell tableCell117 = new TableCell();

            TableCellProperties tableCellProperties117 = new TableCellProperties();
            TableCellWidth tableCellWidth117 = new TableCellWidth() { Width = "742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders115 = new TableCellBorders();
            TopBorder topBorder113 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder104 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder119 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder104 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders115.Append(topBorder113);
            tableCellBorders115.Append(leftBorder104);
            tableCellBorders115.Append(bottomBorder119);
            tableCellBorders115.Append(rightBorder104);
            Shading shading117 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties117.Append(tableCellWidth117);
            tableCellProperties117.Append(tableCellBorders115);
            tableCellProperties117.Append(shading117);

            Paragraph paragraph135 = new Paragraph() { RsidParagraphAddition = "00284D9B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D9B" };

            ParagraphProperties paragraphProperties128 = new ParagraphProperties();
            Justification justification124 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties128.Append(justification124);

            paragraph135.Append(paragraphProperties128);

            tableCell117.Append(tableCellProperties117);
            tableCell117.Append(paragraph135);

            TableCell tableCell118 = new TableCell();

            TableCellProperties tableCellProperties118 = new TableCellProperties();
            TableCellWidth tableCellWidth118 = new TableCellWidth() { Width = "743", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders116 = new TableCellBorders();
            TopBorder topBorder114 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder105 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder120 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder105 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders116.Append(topBorder114);
            tableCellBorders116.Append(leftBorder105);
            tableCellBorders116.Append(bottomBorder120);
            tableCellBorders116.Append(rightBorder105);
            Shading shading118 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties118.Append(tableCellWidth118);
            tableCellProperties118.Append(tableCellBorders116);
            tableCellProperties118.Append(shading118);

            Paragraph paragraph136 = new Paragraph() { RsidParagraphAddition = "00284D9B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D9B" };

            ParagraphProperties paragraphProperties129 = new ParagraphProperties();
            Justification justification125 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties129.Append(justification125);

            paragraph136.Append(paragraphProperties129);

            tableCell118.Append(tableCellProperties118);
            tableCell118.Append(paragraph136);

            TableCell tableCell119 = new TableCell();

            TableCellProperties tableCellProperties119 = new TableCellProperties();
            TableCellWidth tableCellWidth119 = new TableCellWidth() { Width = "742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders117 = new TableCellBorders();
            TopBorder topBorder115 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder106 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder121 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder106 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders117.Append(topBorder115);
            tableCellBorders117.Append(leftBorder106);
            tableCellBorders117.Append(bottomBorder121);
            tableCellBorders117.Append(rightBorder106);
            Shading shading119 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties119.Append(tableCellWidth119);
            tableCellProperties119.Append(tableCellBorders117);
            tableCellProperties119.Append(shading119);

            Paragraph paragraph137 = new Paragraph() { RsidParagraphAddition = "00284D9B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D9B" };

            ParagraphProperties paragraphProperties130 = new ParagraphProperties();
            Justification justification126 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties130.Append(justification126);

            paragraph137.Append(paragraphProperties130);

            tableCell119.Append(tableCellProperties119);
            tableCell119.Append(paragraph137);

            TableCell tableCell120 = new TableCell();

            TableCellProperties tableCellProperties120 = new TableCellProperties();
            TableCellWidth tableCellWidth120 = new TableCellWidth() { Width = "743", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders118 = new TableCellBorders();
            TopBorder topBorder116 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder107 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder122 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder107 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders118.Append(topBorder116);
            tableCellBorders118.Append(leftBorder107);
            tableCellBorders118.Append(bottomBorder122);
            tableCellBorders118.Append(rightBorder107);
            Shading shading120 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties120.Append(tableCellWidth120);
            tableCellProperties120.Append(tableCellBorders118);
            tableCellProperties120.Append(shading120);

            Paragraph paragraph138 = new Paragraph() { RsidParagraphAddition = "00284D9B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D9B" };

            ParagraphProperties paragraphProperties131 = new ParagraphProperties();
            Justification justification127 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties131.Append(justification127);

            paragraph138.Append(paragraphProperties131);

            tableCell120.Append(tableCellProperties120);
            tableCell120.Append(paragraph138);

            TableCell tableCell121 = new TableCell();

            TableCellProperties tableCellProperties121 = new TableCellProperties();
            TableCellWidth tableCellWidth121 = new TableCellWidth() { Width = "742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders119 = new TableCellBorders();
            TopBorder topBorder117 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder108 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder123 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder108 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders119.Append(topBorder117);
            tableCellBorders119.Append(leftBorder108);
            tableCellBorders119.Append(bottomBorder123);
            tableCellBorders119.Append(rightBorder108);
            Shading shading121 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties121.Append(tableCellWidth121);
            tableCellProperties121.Append(tableCellBorders119);
            tableCellProperties121.Append(shading121);

            Paragraph paragraph139 = new Paragraph() { RsidParagraphAddition = "00284D9B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D9B" };

            ParagraphProperties paragraphProperties132 = new ParagraphProperties();
            Justification justification128 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties132.Append(justification128);

            paragraph139.Append(paragraphProperties132);

            tableCell121.Append(tableCellProperties121);
            tableCell121.Append(paragraph139);

            TableCell tableCell122 = new TableCell();

            TableCellProperties tableCellProperties122 = new TableCellProperties();
            TableCellWidth tableCellWidth122 = new TableCellWidth() { Width = "743", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders120 = new TableCellBorders();
            TopBorder topBorder118 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder109 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder124 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder109 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders120.Append(topBorder118);
            tableCellBorders120.Append(leftBorder109);
            tableCellBorders120.Append(bottomBorder124);
            tableCellBorders120.Append(rightBorder109);
            Shading shading122 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties122.Append(tableCellWidth122);
            tableCellProperties122.Append(tableCellBorders120);
            tableCellProperties122.Append(shading122);

            Paragraph paragraph140 = new Paragraph() { RsidParagraphAddition = "00284D9B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D9B" };

            ParagraphProperties paragraphProperties133 = new ParagraphProperties();
            Justification justification129 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties133.Append(justification129);

            paragraph140.Append(paragraphProperties133);

            tableCell122.Append(tableCellProperties122);
            tableCell122.Append(paragraph140);

            TableCell tableCell123 = new TableCell();

            TableCellProperties tableCellProperties123 = new TableCellProperties();
            TableCellWidth tableCellWidth123 = new TableCellWidth() { Width = "2340", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders121 = new TableCellBorders();
            TopBorder topBorder119 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder110 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder125 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder110 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders121.Append(topBorder119);
            tableCellBorders121.Append(leftBorder110);
            tableCellBorders121.Append(bottomBorder125);
            tableCellBorders121.Append(rightBorder110);
            Shading shading123 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties123.Append(tableCellWidth123);
            tableCellProperties123.Append(tableCellBorders121);
            tableCellProperties123.Append(shading123);

            Paragraph paragraph141 = new Paragraph() { RsidParagraphAddition = "00284D9B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D9B" };

            ParagraphProperties paragraphProperties134 = new ParagraphProperties();
            Justification justification130 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties134.Append(justification130);

            paragraph141.Append(paragraphProperties134);

            tableCell123.Append(tableCellProperties123);
            tableCell123.Append(paragraph141);

            TableCell tableCell124 = new TableCell();

            TableCellProperties tableCellProperties124 = new TableCellProperties();
            TableCellWidth tableCellWidth124 = new TableCellWidth() { Width = "2700", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders122 = new TableCellBorders();
            TopBorder topBorder120 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder111 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder126 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder111 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders122.Append(topBorder120);
            tableCellBorders122.Append(leftBorder111);
            tableCellBorders122.Append(bottomBorder126);
            tableCellBorders122.Append(rightBorder111);
            Shading shading124 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties124.Append(tableCellWidth124);
            tableCellProperties124.Append(tableCellBorders122);
            tableCellProperties124.Append(shading124);

            Paragraph paragraph142 = new Paragraph() { RsidParagraphAddition = "00284D9B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D9B" };

            ParagraphProperties paragraphProperties135 = new ParagraphProperties();
            Justification justification131 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties135.Append(justification131);

            paragraph142.Append(paragraphProperties135);

            tableCell124.Append(tableCellProperties124);
            tableCell124.Append(paragraph142);

            tableRow28.Append(tableRowProperties7);
            tableRow28.Append(tableCell114);
            tableRow28.Append(tableCell115);
            tableRow28.Append(tableCell116);
            tableRow28.Append(tableCell117);
            tableRow28.Append(tableCell118);
            tableRow28.Append(tableCell119);
            tableRow28.Append(tableCell120);
            tableRow28.Append(tableCell121);
            tableRow28.Append(tableCell122);
            tableRow28.Append(tableCell123);
            tableRow28.Append(tableCell124);

            TableRow tableRow29 = new TableRow() { RsidTableRowMarkRevision = "00E96696", RsidTableRowAddition = "006E25E8", RsidTableRowProperties = "00E96696" };

            TableRowProperties tableRowProperties8 = new TableRowProperties();
            TableJustification tableJustification6 = new TableJustification() { Val = TableRowAlignmentValues.Center };

            tableRowProperties8.Append(tableJustification6);

            TableCell tableCell125 = new TableCell();

            TableCellProperties tableCellProperties125 = new TableCellProperties();
            TableCellWidth tableCellWidth125 = new TableCellWidth() { Width = "2448", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders123 = new TableCellBorders();
            TopBorder topBorder121 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder112 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder127 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder112 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders123.Append(topBorder121);
            tableCellBorders123.Append(leftBorder112);
            tableCellBorders123.Append(bottomBorder127);
            tableCellBorders123.Append(rightBorder112);
            Shading shading125 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            HideMark hideMark18 = new HideMark();

            tableCellProperties125.Append(tableCellWidth125);
            tableCellProperties125.Append(tableCellBorders123);
            tableCellProperties125.Append(shading125);
            tableCellProperties125.Append(hideMark18);

            Paragraph paragraph143 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D9B" };

            ParagraphProperties paragraphProperties136 = new ParagraphProperties();
            Justification justification132 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties136.Append(justification132);

            Run run90 = new Run();
            Text text89 = new Text();
            text89.Text = "ОРЛ и П ЗРК";

            run90.Append(text89);

            Run run91 = new Run() { RsidRunAddition = "006E25E8" };
            Text text90 = new Text();
            text90.Text = "(зачёт)";

            run91.Append(text90);

            paragraph143.Append(paragraphProperties136);
            paragraph143.Append(run90);
            paragraph143.Append(run91);

            tableCell125.Append(tableCellProperties125);
            tableCell125.Append(paragraph143);

            TableCell tableCell126 = new TableCell();

            TableCellProperties tableCellProperties126 = new TableCellProperties();
            TableCellWidth tableCellWidth126 = new TableCellWidth() { Width = "742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders124 = new TableCellBorders();
            TopBorder topBorder122 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder113 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder128 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder113 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders124.Append(topBorder122);
            tableCellBorders124.Append(leftBorder113);
            tableCellBorders124.Append(bottomBorder128);
            tableCellBorders124.Append(rightBorder113);
            Shading shading126 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties126.Append(tableCellWidth126);
            tableCellProperties126.Append(tableCellBorders124);
            tableCellProperties126.Append(shading126);

            Paragraph paragraph144 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties137 = new ParagraphProperties();
            Justification justification133 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties137.Append(justification133);

            paragraph144.Append(paragraphProperties137);

            tableCell126.Append(tableCellProperties126);
            tableCell126.Append(paragraph144);

            TableCell tableCell127 = new TableCell();

            TableCellProperties tableCellProperties127 = new TableCellProperties();
            TableCellWidth tableCellWidth127 = new TableCellWidth() { Width = "743", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders125 = new TableCellBorders();
            TopBorder topBorder123 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder114 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder129 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder114 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders125.Append(topBorder123);
            tableCellBorders125.Append(leftBorder114);
            tableCellBorders125.Append(bottomBorder129);
            tableCellBorders125.Append(rightBorder114);
            Shading shading127 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties127.Append(tableCellWidth127);
            tableCellProperties127.Append(tableCellBorders125);
            tableCellProperties127.Append(shading127);

            Paragraph paragraph145 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties138 = new ParagraphProperties();
            Justification justification134 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties138.Append(justification134);

            paragraph145.Append(paragraphProperties138);

            tableCell127.Append(tableCellProperties127);
            tableCell127.Append(paragraph145);

            TableCell tableCell128 = new TableCell();

            TableCellProperties tableCellProperties128 = new TableCellProperties();
            TableCellWidth tableCellWidth128 = new TableCellWidth() { Width = "742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders126 = new TableCellBorders();
            TopBorder topBorder124 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder115 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder130 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder115 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders126.Append(topBorder124);
            tableCellBorders126.Append(leftBorder115);
            tableCellBorders126.Append(bottomBorder130);
            tableCellBorders126.Append(rightBorder115);
            Shading shading128 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties128.Append(tableCellWidth128);
            tableCellProperties128.Append(tableCellBorders126);
            tableCellProperties128.Append(shading128);

            Paragraph paragraph146 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties139 = new ParagraphProperties();
            Justification justification135 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties139.Append(justification135);

            paragraph146.Append(paragraphProperties139);

            tableCell128.Append(tableCellProperties128);
            tableCell128.Append(paragraph146);

            TableCell tableCell129 = new TableCell();

            TableCellProperties tableCellProperties129 = new TableCellProperties();
            TableCellWidth tableCellWidth129 = new TableCellWidth() { Width = "743", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders127 = new TableCellBorders();
            TopBorder topBorder125 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder116 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder131 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder116 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders127.Append(topBorder125);
            tableCellBorders127.Append(leftBorder116);
            tableCellBorders127.Append(bottomBorder131);
            tableCellBorders127.Append(rightBorder116);
            Shading shading129 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties129.Append(tableCellWidth129);
            tableCellProperties129.Append(tableCellBorders127);
            tableCellProperties129.Append(shading129);

            Paragraph paragraph147 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties140 = new ParagraphProperties();
            Justification justification136 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties140.Append(justification136);

            paragraph147.Append(paragraphProperties140);

            tableCell129.Append(tableCellProperties129);
            tableCell129.Append(paragraph147);

            TableCell tableCell130 = new TableCell();

            TableCellProperties tableCellProperties130 = new TableCellProperties();
            TableCellWidth tableCellWidth130 = new TableCellWidth() { Width = "742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders128 = new TableCellBorders();
            TopBorder topBorder126 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder117 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder132 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder117 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders128.Append(topBorder126);
            tableCellBorders128.Append(leftBorder117);
            tableCellBorders128.Append(bottomBorder132);
            tableCellBorders128.Append(rightBorder117);
            Shading shading130 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties130.Append(tableCellWidth130);
            tableCellProperties130.Append(tableCellBorders128);
            tableCellProperties130.Append(shading130);

            Paragraph paragraph148 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties141 = new ParagraphProperties();
            Justification justification137 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties141.Append(justification137);

            paragraph148.Append(paragraphProperties141);

            tableCell130.Append(tableCellProperties130);
            tableCell130.Append(paragraph148);

            TableCell tableCell131 = new TableCell();

            TableCellProperties tableCellProperties131 = new TableCellProperties();
            TableCellWidth tableCellWidth131 = new TableCellWidth() { Width = "743", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders129 = new TableCellBorders();
            TopBorder topBorder127 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder118 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder133 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder118 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders129.Append(topBorder127);
            tableCellBorders129.Append(leftBorder118);
            tableCellBorders129.Append(bottomBorder133);
            tableCellBorders129.Append(rightBorder118);
            Shading shading131 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties131.Append(tableCellWidth131);
            tableCellProperties131.Append(tableCellBorders129);
            tableCellProperties131.Append(shading131);

            Paragraph paragraph149 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties142 = new ParagraphProperties();
            Justification justification138 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties142.Append(justification138);

            paragraph149.Append(paragraphProperties142);

            tableCell131.Append(tableCellProperties131);
            tableCell131.Append(paragraph149);

            TableCell tableCell132 = new TableCell();

            TableCellProperties tableCellProperties132 = new TableCellProperties();
            TableCellWidth tableCellWidth132 = new TableCellWidth() { Width = "742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders130 = new TableCellBorders();
            TopBorder topBorder128 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder119 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder134 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder119 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders130.Append(topBorder128);
            tableCellBorders130.Append(leftBorder119);
            tableCellBorders130.Append(bottomBorder134);
            tableCellBorders130.Append(rightBorder119);
            Shading shading132 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties132.Append(tableCellWidth132);
            tableCellProperties132.Append(tableCellBorders130);
            tableCellProperties132.Append(shading132);

            Paragraph paragraph150 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties143 = new ParagraphProperties();
            Justification justification139 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties143.Append(justification139);

            paragraph150.Append(paragraphProperties143);

            tableCell132.Append(tableCellProperties132);
            tableCell132.Append(paragraph150);

            TableCell tableCell133 = new TableCell();

            TableCellProperties tableCellProperties133 = new TableCellProperties();
            TableCellWidth tableCellWidth133 = new TableCellWidth() { Width = "743", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders131 = new TableCellBorders();
            TopBorder topBorder129 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder120 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder135 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder120 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders131.Append(topBorder129);
            tableCellBorders131.Append(leftBorder120);
            tableCellBorders131.Append(bottomBorder135);
            tableCellBorders131.Append(rightBorder120);
            Shading shading133 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties133.Append(tableCellWidth133);
            tableCellProperties133.Append(tableCellBorders131);
            tableCellProperties133.Append(shading133);

            Paragraph paragraph151 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties144 = new ParagraphProperties();
            Justification justification140 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties144.Append(justification140);

            paragraph151.Append(paragraphProperties144);

            tableCell133.Append(tableCellProperties133);
            tableCell133.Append(paragraph151);

            TableCell tableCell134 = new TableCell();

            TableCellProperties tableCellProperties134 = new TableCellProperties();
            TableCellWidth tableCellWidth134 = new TableCellWidth() { Width = "2340", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders132 = new TableCellBorders();
            TopBorder topBorder130 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder121 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder136 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder121 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders132.Append(topBorder130);
            tableCellBorders132.Append(leftBorder121);
            tableCellBorders132.Append(bottomBorder136);
            tableCellBorders132.Append(rightBorder121);
            Shading shading134 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties134.Append(tableCellWidth134);
            tableCellProperties134.Append(tableCellBorders132);
            tableCellProperties134.Append(shading134);

            Paragraph paragraph152 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties145 = new ParagraphProperties();
            Justification justification141 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties145.Append(justification141);

            paragraph152.Append(paragraphProperties145);

            tableCell134.Append(tableCellProperties134);
            tableCell134.Append(paragraph152);

            TableCell tableCell135 = new TableCell();

            TableCellProperties tableCellProperties135 = new TableCellProperties();
            TableCellWidth tableCellWidth135 = new TableCellWidth() { Width = "2700", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders133 = new TableCellBorders();
            TopBorder topBorder131 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder122 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder137 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder122 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders133.Append(topBorder131);
            tableCellBorders133.Append(leftBorder122);
            tableCellBorders133.Append(bottomBorder137);
            tableCellBorders133.Append(rightBorder122);
            Shading shading135 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties135.Append(tableCellWidth135);
            tableCellProperties135.Append(tableCellBorders133);
            tableCellProperties135.Append(shading135);

            Paragraph paragraph153 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties146 = new ParagraphProperties();
            Justification justification142 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties146.Append(justification142);

            paragraph153.Append(paragraphProperties146);

            tableCell135.Append(tableCellProperties135);
            tableCell135.Append(paragraph153);

            tableRow29.Append(tableRowProperties8);
            tableRow29.Append(tableCell125);
            tableRow29.Append(tableCell126);
            tableRow29.Append(tableCell127);
            tableRow29.Append(tableCell128);
            tableRow29.Append(tableCell129);
            tableRow29.Append(tableCell130);
            tableRow29.Append(tableCell131);
            tableRow29.Append(tableCell132);
            tableRow29.Append(tableCell133);
            tableRow29.Append(tableCell134);
            tableRow29.Append(tableCell135);

            TableRow tableRow30 = new TableRow() { RsidTableRowMarkRevision = "00E96696", RsidTableRowAddition = "006E25E8", RsidTableRowProperties = "00E96696" };

            TableRowProperties tableRowProperties9 = new TableRowProperties();
            TableJustification tableJustification7 = new TableJustification() { Val = TableRowAlignmentValues.Center };

            tableRowProperties9.Append(tableJustification7);

            TableCell tableCell136 = new TableCell();

            TableCellProperties tableCellProperties136 = new TableCellProperties();
            TableCellWidth tableCellWidth136 = new TableCellWidth() { Width = "2448", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders134 = new TableCellBorders();
            TopBorder topBorder132 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder123 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder138 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder123 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders134.Append(topBorder132);
            tableCellBorders134.Append(leftBorder123);
            tableCellBorders134.Append(bottomBorder138);
            tableCellBorders134.Append(rightBorder123);
            Shading shading136 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            HideMark hideMark19 = new HideMark();

            tableCellProperties136.Append(tableCellWidth136);
            tableCellProperties136.Append(tableCellBorders134);
            tableCellProperties136.Append(shading136);
            tableCellProperties136.Append(hideMark19);

            Paragraph paragraph154 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D9B" };

            ParagraphProperties paragraphProperties147 = new ParagraphProperties();
            Justification justification143 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties147.Append(justification143);

            Run run92 = new Run();
            Text text91 = new Text();
            text91.Text = "ТПВО(экзамен)";

            run92.Append(text91);

            paragraph154.Append(paragraphProperties147);
            paragraph154.Append(run92);

            tableCell136.Append(tableCellProperties136);
            tableCell136.Append(paragraph154);

            TableCell tableCell137 = new TableCell();

            TableCellProperties tableCellProperties137 = new TableCellProperties();
            TableCellWidth tableCellWidth137 = new TableCellWidth() { Width = "742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders135 = new TableCellBorders();
            TopBorder topBorder133 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder124 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder139 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder124 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders135.Append(topBorder133);
            tableCellBorders135.Append(leftBorder124);
            tableCellBorders135.Append(bottomBorder139);
            tableCellBorders135.Append(rightBorder124);
            Shading shading137 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties137.Append(tableCellWidth137);
            tableCellProperties137.Append(tableCellBorders135);
            tableCellProperties137.Append(shading137);

            Paragraph paragraph155 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties148 = new ParagraphProperties();
            Justification justification144 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties148.Append(justification144);

            paragraph155.Append(paragraphProperties148);

            tableCell137.Append(tableCellProperties137);
            tableCell137.Append(paragraph155);

            TableCell tableCell138 = new TableCell();

            TableCellProperties tableCellProperties138 = new TableCellProperties();
            TableCellWidth tableCellWidth138 = new TableCellWidth() { Width = "743", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders136 = new TableCellBorders();
            TopBorder topBorder134 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder125 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder140 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder125 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders136.Append(topBorder134);
            tableCellBorders136.Append(leftBorder125);
            tableCellBorders136.Append(bottomBorder140);
            tableCellBorders136.Append(rightBorder125);
            Shading shading138 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties138.Append(tableCellWidth138);
            tableCellProperties138.Append(tableCellBorders136);
            tableCellProperties138.Append(shading138);

            Paragraph paragraph156 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties149 = new ParagraphProperties();
            Justification justification145 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties149.Append(justification145);

            paragraph156.Append(paragraphProperties149);

            tableCell138.Append(tableCellProperties138);
            tableCell138.Append(paragraph156);

            TableCell tableCell139 = new TableCell();

            TableCellProperties tableCellProperties139 = new TableCellProperties();
            TableCellWidth tableCellWidth139 = new TableCellWidth() { Width = "742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders137 = new TableCellBorders();
            TopBorder topBorder135 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder126 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder141 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder126 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders137.Append(topBorder135);
            tableCellBorders137.Append(leftBorder126);
            tableCellBorders137.Append(bottomBorder141);
            tableCellBorders137.Append(rightBorder126);
            Shading shading139 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties139.Append(tableCellWidth139);
            tableCellProperties139.Append(tableCellBorders137);
            tableCellProperties139.Append(shading139);

            Paragraph paragraph157 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties150 = new ParagraphProperties();
            Justification justification146 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties150.Append(justification146);

            paragraph157.Append(paragraphProperties150);

            tableCell139.Append(tableCellProperties139);
            tableCell139.Append(paragraph157);

            TableCell tableCell140 = new TableCell();

            TableCellProperties tableCellProperties140 = new TableCellProperties();
            TableCellWidth tableCellWidth140 = new TableCellWidth() { Width = "743", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders138 = new TableCellBorders();
            TopBorder topBorder136 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder127 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder142 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder127 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders138.Append(topBorder136);
            tableCellBorders138.Append(leftBorder127);
            tableCellBorders138.Append(bottomBorder142);
            tableCellBorders138.Append(rightBorder127);
            Shading shading140 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties140.Append(tableCellWidth140);
            tableCellProperties140.Append(tableCellBorders138);
            tableCellProperties140.Append(shading140);

            Paragraph paragraph158 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties151 = new ParagraphProperties();
            Justification justification147 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties151.Append(justification147);

            paragraph158.Append(paragraphProperties151);

            tableCell140.Append(tableCellProperties140);
            tableCell140.Append(paragraph158);

            TableCell tableCell141 = new TableCell();

            TableCellProperties tableCellProperties141 = new TableCellProperties();
            TableCellWidth tableCellWidth141 = new TableCellWidth() { Width = "742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders139 = new TableCellBorders();
            TopBorder topBorder137 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder128 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder143 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder128 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders139.Append(topBorder137);
            tableCellBorders139.Append(leftBorder128);
            tableCellBorders139.Append(bottomBorder143);
            tableCellBorders139.Append(rightBorder128);
            Shading shading141 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties141.Append(tableCellWidth141);
            tableCellProperties141.Append(tableCellBorders139);
            tableCellProperties141.Append(shading141);

            Paragraph paragraph159 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties152 = new ParagraphProperties();
            Justification justification148 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties152.Append(justification148);

            paragraph159.Append(paragraphProperties152);

            tableCell141.Append(tableCellProperties141);
            tableCell141.Append(paragraph159);

            TableCell tableCell142 = new TableCell();

            TableCellProperties tableCellProperties142 = new TableCellProperties();
            TableCellWidth tableCellWidth142 = new TableCellWidth() { Width = "743", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders140 = new TableCellBorders();
            TopBorder topBorder138 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder129 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder144 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder129 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders140.Append(topBorder138);
            tableCellBorders140.Append(leftBorder129);
            tableCellBorders140.Append(bottomBorder144);
            tableCellBorders140.Append(rightBorder129);
            Shading shading142 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties142.Append(tableCellWidth142);
            tableCellProperties142.Append(tableCellBorders140);
            tableCellProperties142.Append(shading142);

            Paragraph paragraph160 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties153 = new ParagraphProperties();
            Justification justification149 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties153.Append(justification149);

            paragraph160.Append(paragraphProperties153);

            tableCell142.Append(tableCellProperties142);
            tableCell142.Append(paragraph160);

            TableCell tableCell143 = new TableCell();

            TableCellProperties tableCellProperties143 = new TableCellProperties();
            TableCellWidth tableCellWidth143 = new TableCellWidth() { Width = "742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders141 = new TableCellBorders();
            TopBorder topBorder139 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder130 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder145 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder130 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders141.Append(topBorder139);
            tableCellBorders141.Append(leftBorder130);
            tableCellBorders141.Append(bottomBorder145);
            tableCellBorders141.Append(rightBorder130);
            Shading shading143 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties143.Append(tableCellWidth143);
            tableCellProperties143.Append(tableCellBorders141);
            tableCellProperties143.Append(shading143);

            Paragraph paragraph161 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties154 = new ParagraphProperties();
            Justification justification150 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties154.Append(justification150);

            paragraph161.Append(paragraphProperties154);

            tableCell143.Append(tableCellProperties143);
            tableCell143.Append(paragraph161);

            TableCell tableCell144 = new TableCell();

            TableCellProperties tableCellProperties144 = new TableCellProperties();
            TableCellWidth tableCellWidth144 = new TableCellWidth() { Width = "743", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders142 = new TableCellBorders();
            TopBorder topBorder140 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder131 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder146 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder131 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders142.Append(topBorder140);
            tableCellBorders142.Append(leftBorder131);
            tableCellBorders142.Append(bottomBorder146);
            tableCellBorders142.Append(rightBorder131);
            Shading shading144 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties144.Append(tableCellWidth144);
            tableCellProperties144.Append(tableCellBorders142);
            tableCellProperties144.Append(shading144);

            Paragraph paragraph162 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties155 = new ParagraphProperties();
            Justification justification151 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties155.Append(justification151);

            paragraph162.Append(paragraphProperties155);

            tableCell144.Append(tableCellProperties144);
            tableCell144.Append(paragraph162);

            TableCell tableCell145 = new TableCell();

            TableCellProperties tableCellProperties145 = new TableCellProperties();
            TableCellWidth tableCellWidth145 = new TableCellWidth() { Width = "2340", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders143 = new TableCellBorders();
            TopBorder topBorder141 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder132 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder147 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder132 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders143.Append(topBorder141);
            tableCellBorders143.Append(leftBorder132);
            tableCellBorders143.Append(bottomBorder147);
            tableCellBorders143.Append(rightBorder132);
            Shading shading145 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties145.Append(tableCellWidth145);
            tableCellProperties145.Append(tableCellBorders143);
            tableCellProperties145.Append(shading145);

            Paragraph paragraph163 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties156 = new ParagraphProperties();
            Justification justification152 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties156.Append(justification152);

            paragraph163.Append(paragraphProperties156);

            tableCell145.Append(tableCellProperties145);
            tableCell145.Append(paragraph163);

            TableCell tableCell146 = new TableCell();

            TableCellProperties tableCellProperties146 = new TableCellProperties();
            TableCellWidth tableCellWidth146 = new TableCellWidth() { Width = "2700", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders144 = new TableCellBorders();
            TopBorder topBorder142 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder133 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder148 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder133 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders144.Append(topBorder142);
            tableCellBorders144.Append(leftBorder133);
            tableCellBorders144.Append(bottomBorder148);
            tableCellBorders144.Append(rightBorder133);
            Shading shading146 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties146.Append(tableCellWidth146);
            tableCellProperties146.Append(tableCellBorders144);
            tableCellProperties146.Append(shading146);

            Paragraph paragraph164 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties157 = new ParagraphProperties();
            Justification justification153 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties157.Append(justification153);

            paragraph164.Append(paragraphProperties157);

            tableCell146.Append(tableCellProperties146);
            tableCell146.Append(paragraph164);

            tableRow30.Append(tableRowProperties9);
            tableRow30.Append(tableCell136);
            tableRow30.Append(tableCell137);
            tableRow30.Append(tableCell138);
            tableRow30.Append(tableCell139);
            tableRow30.Append(tableCell140);
            tableRow30.Append(tableCell141);
            tableRow30.Append(tableCell142);
            tableRow30.Append(tableCell143);
            tableRow30.Append(tableCell144);
            tableRow30.Append(tableCell145);
            tableRow30.Append(tableCell146);

            TableRow tableRow31 = new TableRow() { RsidTableRowMarkRevision = "00E96696", RsidTableRowAddition = "00284D9B", RsidTableRowProperties = "00E96696" };

            TableRowProperties tableRowProperties10 = new TableRowProperties();
            TableJustification tableJustification8 = new TableJustification() { Val = TableRowAlignmentValues.Center };

            tableRowProperties10.Append(tableJustification8);

            TableCell tableCell147 = new TableCell();

            TableCellProperties tableCellProperties147 = new TableCellProperties();
            TableCellWidth tableCellWidth147 = new TableCellWidth() { Width = "2448", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders145 = new TableCellBorders();
            TopBorder topBorder143 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder134 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder149 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder134 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders145.Append(topBorder143);
            tableCellBorders145.Append(leftBorder134);
            tableCellBorders145.Append(bottomBorder149);
            tableCellBorders145.Append(rightBorder134);
            Shading shading147 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            HideMark hideMark20 = new HideMark();

            tableCellProperties147.Append(tableCellWidth147);
            tableCellProperties147.Append(tableCellBorders145);
            tableCellProperties147.Append(shading147);
            tableCellProperties147.Append(hideMark20);

            Paragraph paragraph165 = new Paragraph() { RsidParagraphAddition = "00284D9B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D9B" };

            ParagraphProperties paragraphProperties158 = new ParagraphProperties();
            Justification justification154 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties158.Append(justification154);

            Run run93 = new Run();
            Text text92 = new Text();
            text92.Text = "УиЭ(экзамен)";

            run93.Append(text92);

            paragraph165.Append(paragraphProperties158);
            paragraph165.Append(run93);

            tableCell147.Append(tableCellProperties147);
            tableCell147.Append(paragraph165);

            TableCell tableCell148 = new TableCell();

            TableCellProperties tableCellProperties148 = new TableCellProperties();
            TableCellWidth tableCellWidth148 = new TableCellWidth() { Width = "742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders146 = new TableCellBorders();
            TopBorder topBorder144 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder135 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder150 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder135 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders146.Append(topBorder144);
            tableCellBorders146.Append(leftBorder135);
            tableCellBorders146.Append(bottomBorder150);
            tableCellBorders146.Append(rightBorder135);
            Shading shading148 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties148.Append(tableCellWidth148);
            tableCellProperties148.Append(tableCellBorders146);
            tableCellProperties148.Append(shading148);

            Paragraph paragraph166 = new Paragraph() { RsidParagraphAddition = "00284D9B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D9B" };

            ParagraphProperties paragraphProperties159 = new ParagraphProperties();
            Justification justification155 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties159.Append(justification155);

            paragraph166.Append(paragraphProperties159);

            tableCell148.Append(tableCellProperties148);
            tableCell148.Append(paragraph166);

            TableCell tableCell149 = new TableCell();

            TableCellProperties tableCellProperties149 = new TableCellProperties();
            TableCellWidth tableCellWidth149 = new TableCellWidth() { Width = "743", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders147 = new TableCellBorders();
            TopBorder topBorder145 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder136 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder151 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder136 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders147.Append(topBorder145);
            tableCellBorders147.Append(leftBorder136);
            tableCellBorders147.Append(bottomBorder151);
            tableCellBorders147.Append(rightBorder136);
            Shading shading149 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties149.Append(tableCellWidth149);
            tableCellProperties149.Append(tableCellBorders147);
            tableCellProperties149.Append(shading149);

            Paragraph paragraph167 = new Paragraph() { RsidParagraphAddition = "00284D9B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D9B" };

            ParagraphProperties paragraphProperties160 = new ParagraphProperties();
            Justification justification156 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties160.Append(justification156);

            paragraph167.Append(paragraphProperties160);

            tableCell149.Append(tableCellProperties149);
            tableCell149.Append(paragraph167);

            TableCell tableCell150 = new TableCell();

            TableCellProperties tableCellProperties150 = new TableCellProperties();
            TableCellWidth tableCellWidth150 = new TableCellWidth() { Width = "742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders148 = new TableCellBorders();
            TopBorder topBorder146 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder137 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder152 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder137 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders148.Append(topBorder146);
            tableCellBorders148.Append(leftBorder137);
            tableCellBorders148.Append(bottomBorder152);
            tableCellBorders148.Append(rightBorder137);
            Shading shading150 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties150.Append(tableCellWidth150);
            tableCellProperties150.Append(tableCellBorders148);
            tableCellProperties150.Append(shading150);

            Paragraph paragraph168 = new Paragraph() { RsidParagraphAddition = "00284D9B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D9B" };

            ParagraphProperties paragraphProperties161 = new ParagraphProperties();
            Justification justification157 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties161.Append(justification157);

            paragraph168.Append(paragraphProperties161);

            tableCell150.Append(tableCellProperties150);
            tableCell150.Append(paragraph168);

            TableCell tableCell151 = new TableCell();

            TableCellProperties tableCellProperties151 = new TableCellProperties();
            TableCellWidth tableCellWidth151 = new TableCellWidth() { Width = "743", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders149 = new TableCellBorders();
            TopBorder topBorder147 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder138 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder153 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder138 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders149.Append(topBorder147);
            tableCellBorders149.Append(leftBorder138);
            tableCellBorders149.Append(bottomBorder153);
            tableCellBorders149.Append(rightBorder138);
            Shading shading151 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties151.Append(tableCellWidth151);
            tableCellProperties151.Append(tableCellBorders149);
            tableCellProperties151.Append(shading151);

            Paragraph paragraph169 = new Paragraph() { RsidParagraphAddition = "00284D9B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D9B" };

            ParagraphProperties paragraphProperties162 = new ParagraphProperties();
            Justification justification158 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties162.Append(justification158);

            paragraph169.Append(paragraphProperties162);

            tableCell151.Append(tableCellProperties151);
            tableCell151.Append(paragraph169);

            TableCell tableCell152 = new TableCell();

            TableCellProperties tableCellProperties152 = new TableCellProperties();
            TableCellWidth tableCellWidth152 = new TableCellWidth() { Width = "742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders150 = new TableCellBorders();
            TopBorder topBorder148 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder139 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder154 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder139 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders150.Append(topBorder148);
            tableCellBorders150.Append(leftBorder139);
            tableCellBorders150.Append(bottomBorder154);
            tableCellBorders150.Append(rightBorder139);
            Shading shading152 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties152.Append(tableCellWidth152);
            tableCellProperties152.Append(tableCellBorders150);
            tableCellProperties152.Append(shading152);

            Paragraph paragraph170 = new Paragraph() { RsidParagraphAddition = "00284D9B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D9B" };

            ParagraphProperties paragraphProperties163 = new ParagraphProperties();
            Justification justification159 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties163.Append(justification159);

            paragraph170.Append(paragraphProperties163);

            tableCell152.Append(tableCellProperties152);
            tableCell152.Append(paragraph170);

            TableCell tableCell153 = new TableCell();

            TableCellProperties tableCellProperties153 = new TableCellProperties();
            TableCellWidth tableCellWidth153 = new TableCellWidth() { Width = "743", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders151 = new TableCellBorders();
            TopBorder topBorder149 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder140 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder155 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder140 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders151.Append(topBorder149);
            tableCellBorders151.Append(leftBorder140);
            tableCellBorders151.Append(bottomBorder155);
            tableCellBorders151.Append(rightBorder140);
            Shading shading153 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties153.Append(tableCellWidth153);
            tableCellProperties153.Append(tableCellBorders151);
            tableCellProperties153.Append(shading153);

            Paragraph paragraph171 = new Paragraph() { RsidParagraphAddition = "00284D9B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D9B" };

            ParagraphProperties paragraphProperties164 = new ParagraphProperties();
            Justification justification160 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties164.Append(justification160);

            paragraph171.Append(paragraphProperties164);

            tableCell153.Append(tableCellProperties153);
            tableCell153.Append(paragraph171);

            TableCell tableCell154 = new TableCell();

            TableCellProperties tableCellProperties154 = new TableCellProperties();
            TableCellWidth tableCellWidth154 = new TableCellWidth() { Width = "742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders152 = new TableCellBorders();
            TopBorder topBorder150 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder141 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder156 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder141 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders152.Append(topBorder150);
            tableCellBorders152.Append(leftBorder141);
            tableCellBorders152.Append(bottomBorder156);
            tableCellBorders152.Append(rightBorder141);
            Shading shading154 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties154.Append(tableCellWidth154);
            tableCellProperties154.Append(tableCellBorders152);
            tableCellProperties154.Append(shading154);

            Paragraph paragraph172 = new Paragraph() { RsidParagraphAddition = "00284D9B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D9B" };

            ParagraphProperties paragraphProperties165 = new ParagraphProperties();
            Justification justification161 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties165.Append(justification161);

            paragraph172.Append(paragraphProperties165);

            tableCell154.Append(tableCellProperties154);
            tableCell154.Append(paragraph172);

            TableCell tableCell155 = new TableCell();

            TableCellProperties tableCellProperties155 = new TableCellProperties();
            TableCellWidth tableCellWidth155 = new TableCellWidth() { Width = "743", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders153 = new TableCellBorders();
            TopBorder topBorder151 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder142 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder157 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder142 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders153.Append(topBorder151);
            tableCellBorders153.Append(leftBorder142);
            tableCellBorders153.Append(bottomBorder157);
            tableCellBorders153.Append(rightBorder142);
            Shading shading155 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties155.Append(tableCellWidth155);
            tableCellProperties155.Append(tableCellBorders153);
            tableCellProperties155.Append(shading155);

            Paragraph paragraph173 = new Paragraph() { RsidParagraphAddition = "00284D9B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D9B" };

            ParagraphProperties paragraphProperties166 = new ParagraphProperties();
            Justification justification162 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties166.Append(justification162);

            paragraph173.Append(paragraphProperties166);

            tableCell155.Append(tableCellProperties155);
            tableCell155.Append(paragraph173);

            TableCell tableCell156 = new TableCell();

            TableCellProperties tableCellProperties156 = new TableCellProperties();
            TableCellWidth tableCellWidth156 = new TableCellWidth() { Width = "2340", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders154 = new TableCellBorders();
            TopBorder topBorder152 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder143 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder158 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder143 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders154.Append(topBorder152);
            tableCellBorders154.Append(leftBorder143);
            tableCellBorders154.Append(bottomBorder158);
            tableCellBorders154.Append(rightBorder143);
            Shading shading156 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties156.Append(tableCellWidth156);
            tableCellProperties156.Append(tableCellBorders154);
            tableCellProperties156.Append(shading156);

            Paragraph paragraph174 = new Paragraph() { RsidParagraphAddition = "00284D9B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D9B" };

            ParagraphProperties paragraphProperties167 = new ParagraphProperties();
            Justification justification163 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties167.Append(justification163);

            paragraph174.Append(paragraphProperties167);

            tableCell156.Append(tableCellProperties156);
            tableCell156.Append(paragraph174);

            TableCell tableCell157 = new TableCell();

            TableCellProperties tableCellProperties157 = new TableCellProperties();
            TableCellWidth tableCellWidth157 = new TableCellWidth() { Width = "2700", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders155 = new TableCellBorders();
            TopBorder topBorder153 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder144 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder159 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder144 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders155.Append(topBorder153);
            tableCellBorders155.Append(leftBorder144);
            tableCellBorders155.Append(bottomBorder159);
            tableCellBorders155.Append(rightBorder144);
            Shading shading157 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties157.Append(tableCellWidth157);
            tableCellProperties157.Append(tableCellBorders155);
            tableCellProperties157.Append(shading157);

            Paragraph paragraph175 = new Paragraph() { RsidParagraphAddition = "00284D9B", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "00284D9B" };

            ParagraphProperties paragraphProperties168 = new ParagraphProperties();
            Justification justification164 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties168.Append(justification164);

            paragraph175.Append(paragraphProperties168);

            tableCell157.Append(tableCellProperties157);
            tableCell157.Append(paragraph175);

            tableRow31.Append(tableRowProperties10);
            tableRow31.Append(tableCell147);
            tableRow31.Append(tableCell148);
            tableRow31.Append(tableCell149);
            tableRow31.Append(tableCell150);
            tableRow31.Append(tableCell151);
            tableRow31.Append(tableCell152);
            tableRow31.Append(tableCell153);
            tableRow31.Append(tableCell154);
            tableRow31.Append(tableCell155);
            tableRow31.Append(tableCell156);
            tableRow31.Append(tableCell157);

            TableRow tableRow32 = new TableRow() { RsidTableRowMarkRevision = "00E96696", RsidTableRowAddition = "006E25E8", RsidTableRowProperties = "00E96696" };

            TableRowProperties tableRowProperties11 = new TableRowProperties();
            TableJustification tableJustification9 = new TableJustification() { Val = TableRowAlignmentValues.Center };

            tableRowProperties11.Append(tableJustification9);

            TableCell tableCell158 = new TableCell();

            TableCellProperties tableCellProperties158 = new TableCellProperties();
            TableCellWidth tableCellWidth158 = new TableCellWidth() { Width = "2448", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders156 = new TableCellBorders();
            TopBorder topBorder154 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder145 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder160 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder145 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders156.Append(topBorder154);
            tableCellBorders156.Append(leftBorder145);
            tableCellBorders156.Append(bottomBorder160);
            tableCellBorders156.Append(rightBorder145);
            Shading shading158 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            HideMark hideMark21 = new HideMark();

            tableCellProperties158.Append(tableCellWidth158);
            tableCellProperties158.Append(tableCellBorders156);
            tableCellProperties158.Append(shading158);
            tableCellProperties158.Append(hideMark21);

            Paragraph paragraph176 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00284D9B", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties169 = new ParagraphProperties();
            Justification justification165 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties169.Append(justification165);

            Run run94 = new Run();
            Text text93 = new Text();
            text93.Text = "СиБР";

            run94.Append(text93);

            Run run95 = new Run() { RsidRunAddition = "00284D9B" };
            Text text94 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text94.Text = " и ТПВО";

            run95.Append(text94);

            Run run96 = new Run();
            Text text95 = new Text();
            text95.Text = "(";

            run96.Append(text95);

            Run run97 = new Run() { RsidRunAddition = "00284D9B" };
            Text text96 = new Text();
            text96.Text = "к.экз.)";

            run97.Append(text96);

            paragraph176.Append(paragraphProperties169);
            paragraph176.Append(run94);
            paragraph176.Append(run95);
            paragraph176.Append(run96);
            paragraph176.Append(run97);

            tableCell158.Append(tableCellProperties158);
            tableCell158.Append(paragraph176);

            TableCell tableCell159 = new TableCell();

            TableCellProperties tableCellProperties159 = new TableCellProperties();
            TableCellWidth tableCellWidth159 = new TableCellWidth() { Width = "742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders157 = new TableCellBorders();
            TopBorder topBorder155 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder146 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder161 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder146 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders157.Append(topBorder155);
            tableCellBorders157.Append(leftBorder146);
            tableCellBorders157.Append(bottomBorder161);
            tableCellBorders157.Append(rightBorder146);
            Shading shading159 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties159.Append(tableCellWidth159);
            tableCellProperties159.Append(tableCellBorders157);
            tableCellProperties159.Append(shading159);

            Paragraph paragraph177 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties170 = new ParagraphProperties();
            Justification justification166 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties170.Append(justification166);

            paragraph177.Append(paragraphProperties170);

            tableCell159.Append(tableCellProperties159);
            tableCell159.Append(paragraph177);

            TableCell tableCell160 = new TableCell();

            TableCellProperties tableCellProperties160 = new TableCellProperties();
            TableCellWidth tableCellWidth160 = new TableCellWidth() { Width = "743", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders158 = new TableCellBorders();
            TopBorder topBorder156 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder147 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder162 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder147 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders158.Append(topBorder156);
            tableCellBorders158.Append(leftBorder147);
            tableCellBorders158.Append(bottomBorder162);
            tableCellBorders158.Append(rightBorder147);
            Shading shading160 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties160.Append(tableCellWidth160);
            tableCellProperties160.Append(tableCellBorders158);
            tableCellProperties160.Append(shading160);

            Paragraph paragraph178 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties171 = new ParagraphProperties();
            Justification justification167 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties171.Append(justification167);

            paragraph178.Append(paragraphProperties171);

            tableCell160.Append(tableCellProperties160);
            tableCell160.Append(paragraph178);

            TableCell tableCell161 = new TableCell();

            TableCellProperties tableCellProperties161 = new TableCellProperties();
            TableCellWidth tableCellWidth161 = new TableCellWidth() { Width = "742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders159 = new TableCellBorders();
            TopBorder topBorder157 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder148 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder163 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder148 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders159.Append(topBorder157);
            tableCellBorders159.Append(leftBorder148);
            tableCellBorders159.Append(bottomBorder163);
            tableCellBorders159.Append(rightBorder148);
            Shading shading161 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties161.Append(tableCellWidth161);
            tableCellProperties161.Append(tableCellBorders159);
            tableCellProperties161.Append(shading161);

            Paragraph paragraph179 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties172 = new ParagraphProperties();
            Justification justification168 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties172.Append(justification168);

            paragraph179.Append(paragraphProperties172);

            tableCell161.Append(tableCellProperties161);
            tableCell161.Append(paragraph179);

            TableCell tableCell162 = new TableCell();

            TableCellProperties tableCellProperties162 = new TableCellProperties();
            TableCellWidth tableCellWidth162 = new TableCellWidth() { Width = "743", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders160 = new TableCellBorders();
            TopBorder topBorder158 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder149 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder164 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder149 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders160.Append(topBorder158);
            tableCellBorders160.Append(leftBorder149);
            tableCellBorders160.Append(bottomBorder164);
            tableCellBorders160.Append(rightBorder149);
            Shading shading162 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties162.Append(tableCellWidth162);
            tableCellProperties162.Append(tableCellBorders160);
            tableCellProperties162.Append(shading162);

            Paragraph paragraph180 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties173 = new ParagraphProperties();
            Justification justification169 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties173.Append(justification169);

            paragraph180.Append(paragraphProperties173);

            tableCell162.Append(tableCellProperties162);
            tableCell162.Append(paragraph180);

            TableCell tableCell163 = new TableCell();

            TableCellProperties tableCellProperties163 = new TableCellProperties();
            TableCellWidth tableCellWidth163 = new TableCellWidth() { Width = "742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders161 = new TableCellBorders();
            TopBorder topBorder159 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder150 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder165 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder150 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders161.Append(topBorder159);
            tableCellBorders161.Append(leftBorder150);
            tableCellBorders161.Append(bottomBorder165);
            tableCellBorders161.Append(rightBorder150);
            Shading shading163 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties163.Append(tableCellWidth163);
            tableCellProperties163.Append(tableCellBorders161);
            tableCellProperties163.Append(shading163);

            Paragraph paragraph181 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties174 = new ParagraphProperties();
            Justification justification170 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties174.Append(justification170);

            paragraph181.Append(paragraphProperties174);

            tableCell163.Append(tableCellProperties163);
            tableCell163.Append(paragraph181);

            TableCell tableCell164 = new TableCell();

            TableCellProperties tableCellProperties164 = new TableCellProperties();
            TableCellWidth tableCellWidth164 = new TableCellWidth() { Width = "743", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders162 = new TableCellBorders();
            TopBorder topBorder160 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder151 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder166 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder151 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders162.Append(topBorder160);
            tableCellBorders162.Append(leftBorder151);
            tableCellBorders162.Append(bottomBorder166);
            tableCellBorders162.Append(rightBorder151);
            Shading shading164 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties164.Append(tableCellWidth164);
            tableCellProperties164.Append(tableCellBorders162);
            tableCellProperties164.Append(shading164);

            Paragraph paragraph182 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties175 = new ParagraphProperties();
            Justification justification171 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties175.Append(justification171);

            paragraph182.Append(paragraphProperties175);

            tableCell164.Append(tableCellProperties164);
            tableCell164.Append(paragraph182);

            TableCell tableCell165 = new TableCell();

            TableCellProperties tableCellProperties165 = new TableCellProperties();
            TableCellWidth tableCellWidth165 = new TableCellWidth() { Width = "742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders163 = new TableCellBorders();
            TopBorder topBorder161 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder152 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder167 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder152 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders163.Append(topBorder161);
            tableCellBorders163.Append(leftBorder152);
            tableCellBorders163.Append(bottomBorder167);
            tableCellBorders163.Append(rightBorder152);
            Shading shading165 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties165.Append(tableCellWidth165);
            tableCellProperties165.Append(tableCellBorders163);
            tableCellProperties165.Append(shading165);

            Paragraph paragraph183 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties176 = new ParagraphProperties();
            Justification justification172 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties176.Append(justification172);

            paragraph183.Append(paragraphProperties176);

            tableCell165.Append(tableCellProperties165);
            tableCell165.Append(paragraph183);

            TableCell tableCell166 = new TableCell();

            TableCellProperties tableCellProperties166 = new TableCellProperties();
            TableCellWidth tableCellWidth166 = new TableCellWidth() { Width = "743", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders164 = new TableCellBorders();
            TopBorder topBorder162 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder153 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder168 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder153 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders164.Append(topBorder162);
            tableCellBorders164.Append(leftBorder153);
            tableCellBorders164.Append(bottomBorder168);
            tableCellBorders164.Append(rightBorder153);
            Shading shading166 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties166.Append(tableCellWidth166);
            tableCellProperties166.Append(tableCellBorders164);
            tableCellProperties166.Append(shading166);

            Paragraph paragraph184 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties177 = new ParagraphProperties();
            Justification justification173 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties177.Append(justification173);

            paragraph184.Append(paragraphProperties177);

            tableCell166.Append(tableCellProperties166);
            tableCell166.Append(paragraph184);

            TableCell tableCell167 = new TableCell();

            TableCellProperties tableCellProperties167 = new TableCellProperties();
            TableCellWidth tableCellWidth167 = new TableCellWidth() { Width = "2340", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders165 = new TableCellBorders();
            TopBorder topBorder163 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder154 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder169 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder154 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders165.Append(topBorder163);
            tableCellBorders165.Append(leftBorder154);
            tableCellBorders165.Append(bottomBorder169);
            tableCellBorders165.Append(rightBorder154);
            Shading shading167 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties167.Append(tableCellWidth167);
            tableCellProperties167.Append(tableCellBorders165);
            tableCellProperties167.Append(shading167);

            Paragraph paragraph185 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties178 = new ParagraphProperties();
            Justification justification174 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties178.Append(justification174);

            paragraph185.Append(paragraphProperties178);

            tableCell167.Append(tableCellProperties167);
            tableCell167.Append(paragraph185);

            TableCell tableCell168 = new TableCell();

            TableCellProperties tableCellProperties168 = new TableCellProperties();
            TableCellWidth tableCellWidth168 = new TableCellWidth() { Width = "2700", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders166 = new TableCellBorders();
            TopBorder topBorder164 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder155 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder170 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder155 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders166.Append(topBorder164);
            tableCellBorders166.Append(leftBorder155);
            tableCellBorders166.Append(bottomBorder170);
            tableCellBorders166.Append(rightBorder155);
            Shading shading168 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties168.Append(tableCellWidth168);
            tableCellProperties168.Append(tableCellBorders166);
            tableCellProperties168.Append(shading168);

            Paragraph paragraph186 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties179 = new ParagraphProperties();
            Justification justification175 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties179.Append(justification175);

            paragraph186.Append(paragraphProperties179);

            tableCell168.Append(tableCellProperties168);
            tableCell168.Append(paragraph186);

            tableRow32.Append(tableRowProperties11);
            tableRow32.Append(tableCell158);
            tableRow32.Append(tableCell159);
            tableRow32.Append(tableCell160);
            tableRow32.Append(tableCell161);
            tableRow32.Append(tableCell162);
            tableRow32.Append(tableCell163);
            tableRow32.Append(tableCell164);
            tableRow32.Append(tableCell165);
            tableRow32.Append(tableCell166);
            tableRow32.Append(tableCell167);
            tableRow32.Append(tableCell168);

            table5.Append(tableProperties5);
            table5.Append(tableGrid5);
            table5.Append(tableRow25);
            table5.Append(tableRow26);
            table5.Append(tableRow27);
            table5.Append(tableRow28);
            table5.Append(tableRow29);
            table5.Append(tableRow30);
            table5.Append(tableRow31);
            table5.Append(tableRow32);

            Paragraph paragraph187 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "006E25E8", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties180 = new ParagraphProperties();
            Justification justification176 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties180.Append(justification176);

            paragraph187.Append(paragraphProperties180);

            Paragraph paragraph188 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "006E25E8", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties181 = new ParagraphProperties();
            Justification justification177 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties181.Append(justification177);

            Run run98 = new Run();
            Text text97 = new Text();
            text97.Text = "Пропущено занятий (учебных часов) по семестрам";

            run98.Append(text97);

            paragraph188.Append(paragraphProperties181);
            paragraph188.Append(run98);

            Table table6 = new Table();

            TableProperties tableProperties6 = new TableProperties();
            TableWidth tableWidth6 = new TableWidth() { Width = "0", Type = TableWidthUnitValues.Auto };
            TableJustification tableJustification10 = new TableJustification() { Val = TableRowAlignmentValues.Center };

            TableBorders tableBorders5 = new TableBorders();
            TopBorder topBorder165 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder156 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder171 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder156 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            InsideHorizontalBorder insideHorizontalBorder4 = new InsideHorizontalBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            InsideVerticalBorder insideVerticalBorder4 = new InsideVerticalBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableBorders5.Append(topBorder165);
            tableBorders5.Append(leftBorder156);
            tableBorders5.Append(bottomBorder171);
            tableBorders5.Append(rightBorder156);
            tableBorders5.Append(insideHorizontalBorder4);
            tableBorders5.Append(insideVerticalBorder4);
            TableLook tableLook6 = new TableLook() { Val = "01E0", FirstRow = true, LastRow = true, FirstColumn = true, LastColumn = true, NoHorizontalBand = false, NoVerticalBand = false };

            tableProperties6.Append(tableWidth6);
            tableProperties6.Append(tableJustification10);
            tableProperties6.Append(tableBorders5);
            tableProperties6.Append(tableLook6);

            TableGrid tableGrid6 = new TableGrid();
            GridColumn gridColumn44 = new GridColumn() { Width = "2777" };
            GridColumn gridColumn45 = new GridColumn() { Width = "931" };
            GridColumn gridColumn46 = new GridColumn() { Width = "812" };
            GridColumn gridColumn47 = new GridColumn() { Width = "808" };
            GridColumn gridColumn48 = new GridColumn() { Width = "900" };
            GridColumn gridColumn49 = new GridColumn() { Width = "900" };
            GridColumn gridColumn50 = new GridColumn() { Width = "900" };
            GridColumn gridColumn51 = new GridColumn() { Width = "900" };
            GridColumn gridColumn52 = new GridColumn() { Width = "900" };
            GridColumn gridColumn53 = new GridColumn() { Width = "1800" };

            tableGrid6.Append(gridColumn44);
            tableGrid6.Append(gridColumn45);
            tableGrid6.Append(gridColumn46);
            tableGrid6.Append(gridColumn47);
            tableGrid6.Append(gridColumn48);
            tableGrid6.Append(gridColumn49);
            tableGrid6.Append(gridColumn50);
            tableGrid6.Append(gridColumn51);
            tableGrid6.Append(gridColumn52);
            tableGrid6.Append(gridColumn53);

            TableRow tableRow33 = new TableRow() { RsidTableRowMarkRevision = "00E96696", RsidTableRowAddition = "006E25E8", RsidTableRowProperties = "00E96696" };

            TableRowProperties tableRowProperties12 = new TableRowProperties();
            TableJustification tableJustification11 = new TableJustification() { Val = TableRowAlignmentValues.Center };

            tableRowProperties12.Append(tableJustification11);

            TableCell tableCell169 = new TableCell();

            TableCellProperties tableCellProperties169 = new TableCellProperties();
            TableCellWidth tableCellWidth169 = new TableCellWidth() { Width = "2777", Type = TableWidthUnitValues.Dxa };
            VerticalMerge verticalMerge7 = new VerticalMerge() { Val = MergedCellValues.Restart };

            TableCellBorders tableCellBorders167 = new TableCellBorders();
            TopBorder topBorder166 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder157 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder172 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder157 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders167.Append(topBorder166);
            tableCellBorders167.Append(leftBorder157);
            tableCellBorders167.Append(bottomBorder172);
            tableCellBorders167.Append(rightBorder157);
            Shading shading169 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            HideMark hideMark22 = new HideMark();

            tableCellProperties169.Append(tableCellWidth169);
            tableCellProperties169.Append(verticalMerge7);
            tableCellProperties169.Append(tableCellBorders167);
            tableCellProperties169.Append(shading169);
            tableCellProperties169.Append(hideMark22);

            Paragraph paragraph189 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties182 = new ParagraphProperties();
            Justification justification178 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties182.Append(justification178);

            Run run99 = new Run();
            Text text98 = new Text();
            text98.Text = "Причина";

            run99.Append(text98);

            paragraph189.Append(paragraphProperties182);
            paragraph189.Append(run99);

            tableCell169.Append(tableCellProperties169);
            tableCell169.Append(paragraph189);

            TableCell tableCell170 = new TableCell();

            TableCellProperties tableCellProperties170 = new TableCellProperties();
            TableCellWidth tableCellWidth170 = new TableCellWidth() { Width = "7051", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan62 = new GridSpan() { Val = 8 };

            TableCellBorders tableCellBorders168 = new TableCellBorders();
            TopBorder topBorder167 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder158 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder173 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder158 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders168.Append(topBorder167);
            tableCellBorders168.Append(leftBorder158);
            tableCellBorders168.Append(bottomBorder173);
            tableCellBorders168.Append(rightBorder158);
            Shading shading170 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            HideMark hideMark23 = new HideMark();

            tableCellProperties170.Append(tableCellWidth170);
            tableCellProperties170.Append(gridSpan62);
            tableCellProperties170.Append(tableCellBorders168);
            tableCellProperties170.Append(shading170);
            tableCellProperties170.Append(hideMark23);

            Paragraph paragraph190 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties183 = new ParagraphProperties();
            Justification justification179 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties183.Append(justification179);

            Run run100 = new Run();
            Text text99 = new Text();
            text99.Text = "Семестры";

            run100.Append(text99);

            paragraph190.Append(paragraphProperties183);
            paragraph190.Append(run100);

            tableCell170.Append(tableCellProperties170);
            tableCell170.Append(paragraph190);

            TableCell tableCell171 = new TableCell();

            TableCellProperties tableCellProperties171 = new TableCellProperties();
            TableCellWidth tableCellWidth171 = new TableCellWidth() { Width = "1800", Type = TableWidthUnitValues.Dxa };
            VerticalMerge verticalMerge8 = new VerticalMerge() { Val = MergedCellValues.Restart };

            TableCellBorders tableCellBorders169 = new TableCellBorders();
            TopBorder topBorder168 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder159 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder174 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder159 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders169.Append(topBorder168);
            tableCellBorders169.Append(leftBorder159);
            tableCellBorders169.Append(bottomBorder174);
            tableCellBorders169.Append(rightBorder159);
            Shading shading171 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            HideMark hideMark24 = new HideMark();

            tableCellProperties171.Append(tableCellWidth171);
            tableCellProperties171.Append(verticalMerge8);
            tableCellProperties171.Append(tableCellBorders169);
            tableCellProperties171.Append(shading171);
            tableCellProperties171.Append(hideMark24);

            Paragraph paragraph191 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties184 = new ParagraphProperties();
            Justification justification180 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties184.Append(justification180);

            Run run101 = new Run();
            Text text100 = new Text();
            text100.Text = "Всего";

            run101.Append(text100);

            paragraph191.Append(paragraphProperties184);
            paragraph191.Append(run101);

            tableCell171.Append(tableCellProperties171);
            tableCell171.Append(paragraph191);

            tableRow33.Append(tableRowProperties12);
            tableRow33.Append(tableCell169);
            tableRow33.Append(tableCell170);
            tableRow33.Append(tableCell171);

            TableRow tableRow34 = new TableRow() { RsidTableRowMarkRevision = "00E96696", RsidTableRowAddition = "006E25E8", RsidTableRowProperties = "00E96696" };

            TableRowProperties tableRowProperties13 = new TableRowProperties();
            TableJustification tableJustification12 = new TableJustification() { Val = TableRowAlignmentValues.Center };

            tableRowProperties13.Append(tableJustification12);

            TableCell tableCell172 = new TableCell();

            TableCellProperties tableCellProperties172 = new TableCellProperties();
            TableCellWidth tableCellWidth172 = new TableCellWidth() { Width = "0", Type = TableWidthUnitValues.Auto };
            VerticalMerge verticalMerge9 = new VerticalMerge();

            TableCellBorders tableCellBorders170 = new TableCellBorders();
            TopBorder topBorder169 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder160 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder175 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder160 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders170.Append(topBorder169);
            tableCellBorders170.Append(leftBorder160);
            tableCellBorders170.Append(bottomBorder175);
            tableCellBorders170.Append(rightBorder160);
            Shading shading172 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            TableCellVerticalAlignment tableCellVerticalAlignment14 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };
            HideMark hideMark25 = new HideMark();

            tableCellProperties172.Append(tableCellWidth172);
            tableCellProperties172.Append(verticalMerge9);
            tableCellProperties172.Append(tableCellBorders170);
            tableCellProperties172.Append(shading172);
            tableCellProperties172.Append(tableCellVerticalAlignment14);
            tableCellProperties172.Append(hideMark25);
            Paragraph paragraph192 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidRunAdditionDefault = "006E25E8" };

            tableCell172.Append(tableCellProperties172);
            tableCell172.Append(paragraph192);

            TableCell tableCell173 = new TableCell();

            TableCellProperties tableCellProperties173 = new TableCellProperties();
            TableCellWidth tableCellWidth173 = new TableCellWidth() { Width = "931", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders171 = new TableCellBorders();
            TopBorder topBorder170 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder161 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder176 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder161 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders171.Append(topBorder170);
            tableCellBorders171.Append(leftBorder161);
            tableCellBorders171.Append(bottomBorder176);
            tableCellBorders171.Append(rightBorder161);
            Shading shading173 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            HideMark hideMark26 = new HideMark();

            tableCellProperties173.Append(tableCellWidth173);
            tableCellProperties173.Append(tableCellBorders171);
            tableCellProperties173.Append(shading173);
            tableCellProperties173.Append(hideMark26);

            Paragraph paragraph193 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties185 = new ParagraphProperties();
            Justification justification181 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties185.Append(justification181);

            Run run102 = new Run();
            Text text101 = new Text();
            text101.Text = "3";

            run102.Append(text101);

            paragraph193.Append(paragraphProperties185);
            paragraph193.Append(run102);

            tableCell173.Append(tableCellProperties173);
            tableCell173.Append(paragraph193);

            TableCell tableCell174 = new TableCell();

            TableCellProperties tableCellProperties174 = new TableCellProperties();
            TableCellWidth tableCellWidth174 = new TableCellWidth() { Width = "812", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders172 = new TableCellBorders();
            TopBorder topBorder171 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder162 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder177 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder162 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders172.Append(topBorder171);
            tableCellBorders172.Append(leftBorder162);
            tableCellBorders172.Append(bottomBorder177);
            tableCellBorders172.Append(rightBorder162);
            Shading shading174 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            HideMark hideMark27 = new HideMark();

            tableCellProperties174.Append(tableCellWidth174);
            tableCellProperties174.Append(tableCellBorders172);
            tableCellProperties174.Append(shading174);
            tableCellProperties174.Append(hideMark27);

            Paragraph paragraph194 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties186 = new ParagraphProperties();
            Justification justification182 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties186.Append(justification182);

            Run run103 = new Run();
            Text text102 = new Text();
            text102.Text = "4";

            run103.Append(text102);

            paragraph194.Append(paragraphProperties186);
            paragraph194.Append(run103);

            tableCell174.Append(tableCellProperties174);
            tableCell174.Append(paragraph194);

            TableCell tableCell175 = new TableCell();

            TableCellProperties tableCellProperties175 = new TableCellProperties();
            TableCellWidth tableCellWidth175 = new TableCellWidth() { Width = "808", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders173 = new TableCellBorders();
            TopBorder topBorder172 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder163 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder178 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder163 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders173.Append(topBorder172);
            tableCellBorders173.Append(leftBorder163);
            tableCellBorders173.Append(bottomBorder178);
            tableCellBorders173.Append(rightBorder163);
            Shading shading175 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            HideMark hideMark28 = new HideMark();

            tableCellProperties175.Append(tableCellWidth175);
            tableCellProperties175.Append(tableCellBorders173);
            tableCellProperties175.Append(shading175);
            tableCellProperties175.Append(hideMark28);

            Paragraph paragraph195 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties187 = new ParagraphProperties();
            Justification justification183 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties187.Append(justification183);

            Run run104 = new Run();
            Text text103 = new Text();
            text103.Text = "5";

            run104.Append(text103);

            paragraph195.Append(paragraphProperties187);
            paragraph195.Append(run104);

            tableCell175.Append(tableCellProperties175);
            tableCell175.Append(paragraph195);

            TableCell tableCell176 = new TableCell();

            TableCellProperties tableCellProperties176 = new TableCellProperties();
            TableCellWidth tableCellWidth176 = new TableCellWidth() { Width = "900", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders174 = new TableCellBorders();
            TopBorder topBorder173 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder164 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder179 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder164 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders174.Append(topBorder173);
            tableCellBorders174.Append(leftBorder164);
            tableCellBorders174.Append(bottomBorder179);
            tableCellBorders174.Append(rightBorder164);
            Shading shading176 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            HideMark hideMark29 = new HideMark();

            tableCellProperties176.Append(tableCellWidth176);
            tableCellProperties176.Append(tableCellBorders174);
            tableCellProperties176.Append(shading176);
            tableCellProperties176.Append(hideMark29);

            Paragraph paragraph196 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties188 = new ParagraphProperties();
            Justification justification184 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties188.Append(justification184);

            Run run105 = new Run();
            Text text104 = new Text();
            text104.Text = "6";

            run105.Append(text104);

            paragraph196.Append(paragraphProperties188);
            paragraph196.Append(run105);

            tableCell176.Append(tableCellProperties176);
            tableCell176.Append(paragraph196);

            TableCell tableCell177 = new TableCell();

            TableCellProperties tableCellProperties177 = new TableCellProperties();
            TableCellWidth tableCellWidth177 = new TableCellWidth() { Width = "900", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders175 = new TableCellBorders();
            TopBorder topBorder174 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder165 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder180 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder165 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders175.Append(topBorder174);
            tableCellBorders175.Append(leftBorder165);
            tableCellBorders175.Append(bottomBorder180);
            tableCellBorders175.Append(rightBorder165);
            Shading shading177 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            HideMark hideMark30 = new HideMark();

            tableCellProperties177.Append(tableCellWidth177);
            tableCellProperties177.Append(tableCellBorders175);
            tableCellProperties177.Append(shading177);
            tableCellProperties177.Append(hideMark30);

            Paragraph paragraph197 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties189 = new ParagraphProperties();
            Justification justification185 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties189.Append(justification185);

            Run run106 = new Run();
            Text text105 = new Text();
            text105.Text = "7";

            run106.Append(text105);

            paragraph197.Append(paragraphProperties189);
            paragraph197.Append(run106);

            tableCell177.Append(tableCellProperties177);
            tableCell177.Append(paragraph197);

            TableCell tableCell178 = new TableCell();

            TableCellProperties tableCellProperties178 = new TableCellProperties();
            TableCellWidth tableCellWidth178 = new TableCellWidth() { Width = "900", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders176 = new TableCellBorders();
            TopBorder topBorder175 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder166 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder181 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder166 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders176.Append(topBorder175);
            tableCellBorders176.Append(leftBorder166);
            tableCellBorders176.Append(bottomBorder181);
            tableCellBorders176.Append(rightBorder166);
            Shading shading178 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            HideMark hideMark31 = new HideMark();

            tableCellProperties178.Append(tableCellWidth178);
            tableCellProperties178.Append(tableCellBorders176);
            tableCellProperties178.Append(shading178);
            tableCellProperties178.Append(hideMark31);

            Paragraph paragraph198 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties190 = new ParagraphProperties();
            Justification justification186 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties190.Append(justification186);

            Run run107 = new Run();
            Text text106 = new Text();
            text106.Text = "8";

            run107.Append(text106);

            paragraph198.Append(paragraphProperties190);
            paragraph198.Append(run107);

            tableCell178.Append(tableCellProperties178);
            tableCell178.Append(paragraph198);

            TableCell tableCell179 = new TableCell();

            TableCellProperties tableCellProperties179 = new TableCellProperties();
            TableCellWidth tableCellWidth179 = new TableCellWidth() { Width = "900", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders177 = new TableCellBorders();
            TopBorder topBorder176 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder167 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder182 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder167 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders177.Append(topBorder176);
            tableCellBorders177.Append(leftBorder167);
            tableCellBorders177.Append(bottomBorder182);
            tableCellBorders177.Append(rightBorder167);
            Shading shading179 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            HideMark hideMark32 = new HideMark();

            tableCellProperties179.Append(tableCellWidth179);
            tableCellProperties179.Append(tableCellBorders177);
            tableCellProperties179.Append(shading179);
            tableCellProperties179.Append(hideMark32);

            Paragraph paragraph199 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties191 = new ParagraphProperties();
            Justification justification187 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties191.Append(justification187);

            Run run108 = new Run();
            Text text107 = new Text();
            text107.Text = "9";

            run108.Append(text107);

            paragraph199.Append(paragraphProperties191);
            paragraph199.Append(run108);

            tableCell179.Append(tableCellProperties179);
            tableCell179.Append(paragraph199);

            TableCell tableCell180 = new TableCell();

            TableCellProperties tableCellProperties180 = new TableCellProperties();
            TableCellWidth tableCellWidth180 = new TableCellWidth() { Width = "900", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders178 = new TableCellBorders();
            TopBorder topBorder177 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder168 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder183 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder168 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders178.Append(topBorder177);
            tableCellBorders178.Append(leftBorder168);
            tableCellBorders178.Append(bottomBorder183);
            tableCellBorders178.Append(rightBorder168);
            Shading shading180 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            HideMark hideMark33 = new HideMark();

            tableCellProperties180.Append(tableCellWidth180);
            tableCellProperties180.Append(tableCellBorders178);
            tableCellProperties180.Append(shading180);
            tableCellProperties180.Append(hideMark33);

            Paragraph paragraph200 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties192 = new ParagraphProperties();
            Justification justification188 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties192.Append(justification188);

            Run run109 = new Run();
            Text text108 = new Text();
            text108.Text = "10";

            run109.Append(text108);

            paragraph200.Append(paragraphProperties192);
            paragraph200.Append(run109);

            tableCell180.Append(tableCellProperties180);
            tableCell180.Append(paragraph200);

            TableCell tableCell181 = new TableCell();

            TableCellProperties tableCellProperties181 = new TableCellProperties();
            TableCellWidth tableCellWidth181 = new TableCellWidth() { Width = "0", Type = TableWidthUnitValues.Auto };
            VerticalMerge verticalMerge10 = new VerticalMerge();

            TableCellBorders tableCellBorders179 = new TableCellBorders();
            TopBorder topBorder178 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder169 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder184 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder169 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders179.Append(topBorder178);
            tableCellBorders179.Append(leftBorder169);
            tableCellBorders179.Append(bottomBorder184);
            tableCellBorders179.Append(rightBorder169);
            Shading shading181 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            TableCellVerticalAlignment tableCellVerticalAlignment15 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };
            HideMark hideMark34 = new HideMark();

            tableCellProperties181.Append(tableCellWidth181);
            tableCellProperties181.Append(verticalMerge10);
            tableCellProperties181.Append(tableCellBorders179);
            tableCellProperties181.Append(shading181);
            tableCellProperties181.Append(tableCellVerticalAlignment15);
            tableCellProperties181.Append(hideMark34);
            Paragraph paragraph201 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidRunAdditionDefault = "006E25E8" };

            tableCell181.Append(tableCellProperties181);
            tableCell181.Append(paragraph201);

            tableRow34.Append(tableRowProperties13);
            tableRow34.Append(tableCell172);
            tableRow34.Append(tableCell173);
            tableRow34.Append(tableCell174);
            tableRow34.Append(tableCell175);
            tableRow34.Append(tableCell176);
            tableRow34.Append(tableCell177);
            tableRow34.Append(tableCell178);
            tableRow34.Append(tableCell179);
            tableRow34.Append(tableCell180);
            tableRow34.Append(tableCell181);

            TableRow tableRow35 = new TableRow() { RsidTableRowMarkRevision = "00E96696", RsidTableRowAddition = "006E25E8", RsidTableRowProperties = "00E96696" };

            TableRowProperties tableRowProperties14 = new TableRowProperties();
            TableJustification tableJustification13 = new TableJustification() { Val = TableRowAlignmentValues.Center };

            tableRowProperties14.Append(tableJustification13);

            TableCell tableCell182 = new TableCell();

            TableCellProperties tableCellProperties182 = new TableCellProperties();
            TableCellWidth tableCellWidth182 = new TableCellWidth() { Width = "2777", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders180 = new TableCellBorders();
            TopBorder topBorder179 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder170 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder185 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder170 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders180.Append(topBorder179);
            tableCellBorders180.Append(leftBorder170);
            tableCellBorders180.Append(bottomBorder185);
            tableCellBorders180.Append(rightBorder170);
            Shading shading182 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            HideMark hideMark35 = new HideMark();

            tableCellProperties182.Append(tableCellWidth182);
            tableCellProperties182.Append(tableCellBorders180);
            tableCellProperties182.Append(shading182);
            tableCellProperties182.Append(hideMark35);

            Paragraph paragraph202 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties193 = new ParagraphProperties();
            Justification justification189 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties193.Append(justification189);

            Run run110 = new Run();
            Text text109 = new Text();
            text109.Text = "Уважительная";

            run110.Append(text109);

            paragraph202.Append(paragraphProperties193);
            paragraph202.Append(run110);

            tableCell182.Append(tableCellProperties182);
            tableCell182.Append(paragraph202);

            TableCell tableCell183 = new TableCell();

            TableCellProperties tableCellProperties183 = new TableCellProperties();
            TableCellWidth tableCellWidth183 = new TableCellWidth() { Width = "931", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders181 = new TableCellBorders();
            TopBorder topBorder180 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder171 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder186 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder171 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders181.Append(topBorder180);
            tableCellBorders181.Append(leftBorder171);
            tableCellBorders181.Append(bottomBorder186);
            tableCellBorders181.Append(rightBorder171);
            Shading shading183 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties183.Append(tableCellWidth183);
            tableCellProperties183.Append(tableCellBorders181);
            tableCellProperties183.Append(shading183);

            Paragraph paragraph203 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties194 = new ParagraphProperties();
            Justification justification190 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties194.Append(justification190);

            paragraph203.Append(paragraphProperties194);

            tableCell183.Append(tableCellProperties183);
            tableCell183.Append(paragraph203);

            TableCell tableCell184 = new TableCell();

            TableCellProperties tableCellProperties184 = new TableCellProperties();
            TableCellWidth tableCellWidth184 = new TableCellWidth() { Width = "812", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders182 = new TableCellBorders();
            TopBorder topBorder181 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder172 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder187 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder172 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders182.Append(topBorder181);
            tableCellBorders182.Append(leftBorder172);
            tableCellBorders182.Append(bottomBorder187);
            tableCellBorders182.Append(rightBorder172);
            Shading shading184 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties184.Append(tableCellWidth184);
            tableCellProperties184.Append(tableCellBorders182);
            tableCellProperties184.Append(shading184);

            Paragraph paragraph204 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties195 = new ParagraphProperties();
            Justification justification191 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties195.Append(justification191);

            paragraph204.Append(paragraphProperties195);

            tableCell184.Append(tableCellProperties184);
            tableCell184.Append(paragraph204);

            TableCell tableCell185 = new TableCell();

            TableCellProperties tableCellProperties185 = new TableCellProperties();
            TableCellWidth tableCellWidth185 = new TableCellWidth() { Width = "808", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders183 = new TableCellBorders();
            TopBorder topBorder182 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder173 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder188 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder173 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders183.Append(topBorder182);
            tableCellBorders183.Append(leftBorder173);
            tableCellBorders183.Append(bottomBorder188);
            tableCellBorders183.Append(rightBorder173);
            Shading shading185 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties185.Append(tableCellWidth185);
            tableCellProperties185.Append(tableCellBorders183);
            tableCellProperties185.Append(shading185);

            Paragraph paragraph205 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties196 = new ParagraphProperties();
            Justification justification192 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties196.Append(justification192);

            paragraph205.Append(paragraphProperties196);

            tableCell185.Append(tableCellProperties185);
            tableCell185.Append(paragraph205);

            TableCell tableCell186 = new TableCell();

            TableCellProperties tableCellProperties186 = new TableCellProperties();
            TableCellWidth tableCellWidth186 = new TableCellWidth() { Width = "900", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders184 = new TableCellBorders();
            TopBorder topBorder183 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder174 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder189 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder174 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders184.Append(topBorder183);
            tableCellBorders184.Append(leftBorder174);
            tableCellBorders184.Append(bottomBorder189);
            tableCellBorders184.Append(rightBorder174);
            Shading shading186 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties186.Append(tableCellWidth186);
            tableCellProperties186.Append(tableCellBorders184);
            tableCellProperties186.Append(shading186);

            Paragraph paragraph206 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties197 = new ParagraphProperties();
            Justification justification193 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties197.Append(justification193);

            paragraph206.Append(paragraphProperties197);

            tableCell186.Append(tableCellProperties186);
            tableCell186.Append(paragraph206);

            TableCell tableCell187 = new TableCell();

            TableCellProperties tableCellProperties187 = new TableCellProperties();
            TableCellWidth tableCellWidth187 = new TableCellWidth() { Width = "900", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders185 = new TableCellBorders();
            TopBorder topBorder184 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder175 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder190 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder175 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders185.Append(topBorder184);
            tableCellBorders185.Append(leftBorder175);
            tableCellBorders185.Append(bottomBorder190);
            tableCellBorders185.Append(rightBorder175);
            Shading shading187 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties187.Append(tableCellWidth187);
            tableCellProperties187.Append(tableCellBorders185);
            tableCellProperties187.Append(shading187);

            Paragraph paragraph207 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties198 = new ParagraphProperties();
            Justification justification194 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties198.Append(justification194);

            paragraph207.Append(paragraphProperties198);

            tableCell187.Append(tableCellProperties187);
            tableCell187.Append(paragraph207);

            TableCell tableCell188 = new TableCell();

            TableCellProperties tableCellProperties188 = new TableCellProperties();
            TableCellWidth tableCellWidth188 = new TableCellWidth() { Width = "900", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders186 = new TableCellBorders();
            TopBorder topBorder185 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder176 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder191 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder176 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders186.Append(topBorder185);
            tableCellBorders186.Append(leftBorder176);
            tableCellBorders186.Append(bottomBorder191);
            tableCellBorders186.Append(rightBorder176);
            Shading shading188 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties188.Append(tableCellWidth188);
            tableCellProperties188.Append(tableCellBorders186);
            tableCellProperties188.Append(shading188);

            Paragraph paragraph208 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties199 = new ParagraphProperties();
            Justification justification195 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties199.Append(justification195);

            paragraph208.Append(paragraphProperties199);

            tableCell188.Append(tableCellProperties188);
            tableCell188.Append(paragraph208);

            TableCell tableCell189 = new TableCell();

            TableCellProperties tableCellProperties189 = new TableCellProperties();
            TableCellWidth tableCellWidth189 = new TableCellWidth() { Width = "900", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders187 = new TableCellBorders();
            TopBorder topBorder186 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder177 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder192 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder177 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders187.Append(topBorder186);
            tableCellBorders187.Append(leftBorder177);
            tableCellBorders187.Append(bottomBorder192);
            tableCellBorders187.Append(rightBorder177);
            Shading shading189 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties189.Append(tableCellWidth189);
            tableCellProperties189.Append(tableCellBorders187);
            tableCellProperties189.Append(shading189);

            Paragraph paragraph209 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties200 = new ParagraphProperties();
            Justification justification196 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties200.Append(justification196);

            paragraph209.Append(paragraphProperties200);

            tableCell189.Append(tableCellProperties189);
            tableCell189.Append(paragraph209);

            TableCell tableCell190 = new TableCell();

            TableCellProperties tableCellProperties190 = new TableCellProperties();
            TableCellWidth tableCellWidth190 = new TableCellWidth() { Width = "900", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders188 = new TableCellBorders();
            TopBorder topBorder187 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder178 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder193 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder178 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders188.Append(topBorder187);
            tableCellBorders188.Append(leftBorder178);
            tableCellBorders188.Append(bottomBorder193);
            tableCellBorders188.Append(rightBorder178);
            Shading shading190 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties190.Append(tableCellWidth190);
            tableCellProperties190.Append(tableCellBorders188);
            tableCellProperties190.Append(shading190);

            Paragraph paragraph210 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties201 = new ParagraphProperties();
            Justification justification197 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties201.Append(justification197);

            paragraph210.Append(paragraphProperties201);

            tableCell190.Append(tableCellProperties190);
            tableCell190.Append(paragraph210);

            TableCell tableCell191 = new TableCell();

            TableCellProperties tableCellProperties191 = new TableCellProperties();
            TableCellWidth tableCellWidth191 = new TableCellWidth() { Width = "1800", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders189 = new TableCellBorders();
            TopBorder topBorder188 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder179 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder194 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder179 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders189.Append(topBorder188);
            tableCellBorders189.Append(leftBorder179);
            tableCellBorders189.Append(bottomBorder194);
            tableCellBorders189.Append(rightBorder179);
            Shading shading191 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties191.Append(tableCellWidth191);
            tableCellProperties191.Append(tableCellBorders189);
            tableCellProperties191.Append(shading191);

            Paragraph paragraph211 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties202 = new ParagraphProperties();
            Justification justification198 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties202.Append(justification198);

            paragraph211.Append(paragraphProperties202);

            tableCell191.Append(tableCellProperties191);
            tableCell191.Append(paragraph211);

            tableRow35.Append(tableRowProperties14);
            tableRow35.Append(tableCell182);
            tableRow35.Append(tableCell183);
            tableRow35.Append(tableCell184);
            tableRow35.Append(tableCell185);
            tableRow35.Append(tableCell186);
            tableRow35.Append(tableCell187);
            tableRow35.Append(tableCell188);
            tableRow35.Append(tableCell189);
            tableRow35.Append(tableCell190);
            tableRow35.Append(tableCell191);

            TableRow tableRow36 = new TableRow() { RsidTableRowMarkRevision = "00E96696", RsidTableRowAddition = "006E25E8", RsidTableRowProperties = "00E96696" };

            TableRowProperties tableRowProperties15 = new TableRowProperties();
            TableJustification tableJustification14 = new TableJustification() { Val = TableRowAlignmentValues.Center };

            tableRowProperties15.Append(tableJustification14);

            TableCell tableCell192 = new TableCell();

            TableCellProperties tableCellProperties192 = new TableCellProperties();
            TableCellWidth tableCellWidth192 = new TableCellWidth() { Width = "2777", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders190 = new TableCellBorders();
            TopBorder topBorder189 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder180 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder195 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder180 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders190.Append(topBorder189);
            tableCellBorders190.Append(leftBorder180);
            tableCellBorders190.Append(bottomBorder195);
            tableCellBorders190.Append(rightBorder180);
            Shading shading192 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            HideMark hideMark36 = new HideMark();

            tableCellProperties192.Append(tableCellWidth192);
            tableCellProperties192.Append(tableCellBorders190);
            tableCellProperties192.Append(shading192);
            tableCellProperties192.Append(hideMark36);

            Paragraph paragraph212 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties203 = new ParagraphProperties();
            Justification justification199 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties203.Append(justification199);

            Run run111 = new Run();
            Text text110 = new Text();
            text110.Text = "Неуважительная";

            run111.Append(text110);

            paragraph212.Append(paragraphProperties203);
            paragraph212.Append(run111);

            tableCell192.Append(tableCellProperties192);
            tableCell192.Append(paragraph212);

            TableCell tableCell193 = new TableCell();

            TableCellProperties tableCellProperties193 = new TableCellProperties();
            TableCellWidth tableCellWidth193 = new TableCellWidth() { Width = "931", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders191 = new TableCellBorders();
            TopBorder topBorder190 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder181 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder196 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder181 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders191.Append(topBorder190);
            tableCellBorders191.Append(leftBorder181);
            tableCellBorders191.Append(bottomBorder196);
            tableCellBorders191.Append(rightBorder181);
            Shading shading193 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties193.Append(tableCellWidth193);
            tableCellProperties193.Append(tableCellBorders191);
            tableCellProperties193.Append(shading193);

            Paragraph paragraph213 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties204 = new ParagraphProperties();
            Justification justification200 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties204.Append(justification200);

            paragraph213.Append(paragraphProperties204);

            tableCell193.Append(tableCellProperties193);
            tableCell193.Append(paragraph213);

            TableCell tableCell194 = new TableCell();

            TableCellProperties tableCellProperties194 = new TableCellProperties();
            TableCellWidth tableCellWidth194 = new TableCellWidth() { Width = "812", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders192 = new TableCellBorders();
            TopBorder topBorder191 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder182 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder197 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder182 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders192.Append(topBorder191);
            tableCellBorders192.Append(leftBorder182);
            tableCellBorders192.Append(bottomBorder197);
            tableCellBorders192.Append(rightBorder182);
            Shading shading194 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties194.Append(tableCellWidth194);
            tableCellProperties194.Append(tableCellBorders192);
            tableCellProperties194.Append(shading194);

            Paragraph paragraph214 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties205 = new ParagraphProperties();
            Justification justification201 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties205.Append(justification201);

            paragraph214.Append(paragraphProperties205);

            tableCell194.Append(tableCellProperties194);
            tableCell194.Append(paragraph214);

            TableCell tableCell195 = new TableCell();

            TableCellProperties tableCellProperties195 = new TableCellProperties();
            TableCellWidth tableCellWidth195 = new TableCellWidth() { Width = "808", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders193 = new TableCellBorders();
            TopBorder topBorder192 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder183 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder198 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder183 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders193.Append(topBorder192);
            tableCellBorders193.Append(leftBorder183);
            tableCellBorders193.Append(bottomBorder198);
            tableCellBorders193.Append(rightBorder183);
            Shading shading195 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties195.Append(tableCellWidth195);
            tableCellProperties195.Append(tableCellBorders193);
            tableCellProperties195.Append(shading195);

            Paragraph paragraph215 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties206 = new ParagraphProperties();
            Justification justification202 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties206.Append(justification202);

            paragraph215.Append(paragraphProperties206);

            tableCell195.Append(tableCellProperties195);
            tableCell195.Append(paragraph215);

            TableCell tableCell196 = new TableCell();

            TableCellProperties tableCellProperties196 = new TableCellProperties();
            TableCellWidth tableCellWidth196 = new TableCellWidth() { Width = "900", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders194 = new TableCellBorders();
            TopBorder topBorder193 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder184 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder199 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder184 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders194.Append(topBorder193);
            tableCellBorders194.Append(leftBorder184);
            tableCellBorders194.Append(bottomBorder199);
            tableCellBorders194.Append(rightBorder184);
            Shading shading196 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties196.Append(tableCellWidth196);
            tableCellProperties196.Append(tableCellBorders194);
            tableCellProperties196.Append(shading196);

            Paragraph paragraph216 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties207 = new ParagraphProperties();
            Justification justification203 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties207.Append(justification203);

            paragraph216.Append(paragraphProperties207);

            tableCell196.Append(tableCellProperties196);
            tableCell196.Append(paragraph216);

            TableCell tableCell197 = new TableCell();

            TableCellProperties tableCellProperties197 = new TableCellProperties();
            TableCellWidth tableCellWidth197 = new TableCellWidth() { Width = "900", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders195 = new TableCellBorders();
            TopBorder topBorder194 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder185 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder200 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder185 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders195.Append(topBorder194);
            tableCellBorders195.Append(leftBorder185);
            tableCellBorders195.Append(bottomBorder200);
            tableCellBorders195.Append(rightBorder185);
            Shading shading197 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties197.Append(tableCellWidth197);
            tableCellProperties197.Append(tableCellBorders195);
            tableCellProperties197.Append(shading197);

            Paragraph paragraph217 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties208 = new ParagraphProperties();
            Justification justification204 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties208.Append(justification204);

            paragraph217.Append(paragraphProperties208);

            tableCell197.Append(tableCellProperties197);
            tableCell197.Append(paragraph217);

            TableCell tableCell198 = new TableCell();

            TableCellProperties tableCellProperties198 = new TableCellProperties();
            TableCellWidth tableCellWidth198 = new TableCellWidth() { Width = "900", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders196 = new TableCellBorders();
            TopBorder topBorder195 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder186 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder201 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder186 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders196.Append(topBorder195);
            tableCellBorders196.Append(leftBorder186);
            tableCellBorders196.Append(bottomBorder201);
            tableCellBorders196.Append(rightBorder186);
            Shading shading198 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties198.Append(tableCellWidth198);
            tableCellProperties198.Append(tableCellBorders196);
            tableCellProperties198.Append(shading198);

            Paragraph paragraph218 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties209 = new ParagraphProperties();
            Justification justification205 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties209.Append(justification205);

            paragraph218.Append(paragraphProperties209);

            tableCell198.Append(tableCellProperties198);
            tableCell198.Append(paragraph218);

            TableCell tableCell199 = new TableCell();

            TableCellProperties tableCellProperties199 = new TableCellProperties();
            TableCellWidth tableCellWidth199 = new TableCellWidth() { Width = "900", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders197 = new TableCellBorders();
            TopBorder topBorder196 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder187 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder202 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder187 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders197.Append(topBorder196);
            tableCellBorders197.Append(leftBorder187);
            tableCellBorders197.Append(bottomBorder202);
            tableCellBorders197.Append(rightBorder187);
            Shading shading199 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties199.Append(tableCellWidth199);
            tableCellProperties199.Append(tableCellBorders197);
            tableCellProperties199.Append(shading199);

            Paragraph paragraph219 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties210 = new ParagraphProperties();
            Justification justification206 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties210.Append(justification206);

            paragraph219.Append(paragraphProperties210);

            tableCell199.Append(tableCellProperties199);
            tableCell199.Append(paragraph219);

            TableCell tableCell200 = new TableCell();

            TableCellProperties tableCellProperties200 = new TableCellProperties();
            TableCellWidth tableCellWidth200 = new TableCellWidth() { Width = "900", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders198 = new TableCellBorders();
            TopBorder topBorder197 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder188 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder203 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder188 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders198.Append(topBorder197);
            tableCellBorders198.Append(leftBorder188);
            tableCellBorders198.Append(bottomBorder203);
            tableCellBorders198.Append(rightBorder188);
            Shading shading200 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties200.Append(tableCellWidth200);
            tableCellProperties200.Append(tableCellBorders198);
            tableCellProperties200.Append(shading200);

            Paragraph paragraph220 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties211 = new ParagraphProperties();
            Justification justification207 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties211.Append(justification207);

            paragraph220.Append(paragraphProperties211);

            tableCell200.Append(tableCellProperties200);
            tableCell200.Append(paragraph220);

            TableCell tableCell201 = new TableCell();

            TableCellProperties tableCellProperties201 = new TableCellProperties();
            TableCellWidth tableCellWidth201 = new TableCellWidth() { Width = "1800", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders199 = new TableCellBorders();
            TopBorder topBorder198 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder189 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder204 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder189 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders199.Append(topBorder198);
            tableCellBorders199.Append(leftBorder189);
            tableCellBorders199.Append(bottomBorder204);
            tableCellBorders199.Append(rightBorder189);
            Shading shading201 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties201.Append(tableCellWidth201);
            tableCellProperties201.Append(tableCellBorders199);
            tableCellProperties201.Append(shading201);

            Paragraph paragraph221 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties212 = new ParagraphProperties();
            Justification justification208 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties212.Append(justification208);

            paragraph221.Append(paragraphProperties212);

            tableCell201.Append(tableCellProperties201);
            tableCell201.Append(paragraph221);

            tableRow36.Append(tableRowProperties15);
            tableRow36.Append(tableCell192);
            tableRow36.Append(tableCell193);
            tableRow36.Append(tableCell194);
            tableRow36.Append(tableCell195);
            tableRow36.Append(tableCell196);
            tableRow36.Append(tableCell197);
            tableRow36.Append(tableCell198);
            tableRow36.Append(tableCell199);
            tableRow36.Append(tableCell200);
            tableRow36.Append(tableCell201);

            TableRow tableRow37 = new TableRow() { RsidTableRowMarkRevision = "00E96696", RsidTableRowAddition = "006E25E8", RsidTableRowProperties = "00E96696" };

            TableRowProperties tableRowProperties16 = new TableRowProperties();
            TableJustification tableJustification15 = new TableJustification() { Val = TableRowAlignmentValues.Center };

            tableRowProperties16.Append(tableJustification15);

            TableCell tableCell202 = new TableCell();

            TableCellProperties tableCellProperties202 = new TableCellProperties();
            TableCellWidth tableCellWidth202 = new TableCellWidth() { Width = "2777", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders200 = new TableCellBorders();
            TopBorder topBorder199 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder190 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder205 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder190 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders200.Append(topBorder199);
            tableCellBorders200.Append(leftBorder190);
            tableCellBorders200.Append(bottomBorder205);
            tableCellBorders200.Append(rightBorder190);
            Shading shading202 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            HideMark hideMark37 = new HideMark();

            tableCellProperties202.Append(tableCellWidth202);
            tableCellProperties202.Append(tableCellBorders200);
            tableCellProperties202.Append(shading202);
            tableCellProperties202.Append(hideMark37);

            Paragraph paragraph222 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties213 = new ParagraphProperties();
            Justification justification209 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties213.Append(justification209);

            Run run112 = new Run();
            Text text111 = new Text();
            text111.Text = "Всего";

            run112.Append(text111);

            paragraph222.Append(paragraphProperties213);
            paragraph222.Append(run112);

            tableCell202.Append(tableCellProperties202);
            tableCell202.Append(paragraph222);

            TableCell tableCell203 = new TableCell();

            TableCellProperties tableCellProperties203 = new TableCellProperties();
            TableCellWidth tableCellWidth203 = new TableCellWidth() { Width = "931", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders201 = new TableCellBorders();
            TopBorder topBorder200 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder191 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder206 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder191 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders201.Append(topBorder200);
            tableCellBorders201.Append(leftBorder191);
            tableCellBorders201.Append(bottomBorder206);
            tableCellBorders201.Append(rightBorder191);
            Shading shading203 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties203.Append(tableCellWidth203);
            tableCellProperties203.Append(tableCellBorders201);
            tableCellProperties203.Append(shading203);

            Paragraph paragraph223 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties214 = new ParagraphProperties();
            Justification justification210 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties214.Append(justification210);

            paragraph223.Append(paragraphProperties214);

            tableCell203.Append(tableCellProperties203);
            tableCell203.Append(paragraph223);

            TableCell tableCell204 = new TableCell();

            TableCellProperties tableCellProperties204 = new TableCellProperties();
            TableCellWidth tableCellWidth204 = new TableCellWidth() { Width = "812", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders202 = new TableCellBorders();
            TopBorder topBorder201 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder192 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder207 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder192 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders202.Append(topBorder201);
            tableCellBorders202.Append(leftBorder192);
            tableCellBorders202.Append(bottomBorder207);
            tableCellBorders202.Append(rightBorder192);
            Shading shading204 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties204.Append(tableCellWidth204);
            tableCellProperties204.Append(tableCellBorders202);
            tableCellProperties204.Append(shading204);

            Paragraph paragraph224 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties215 = new ParagraphProperties();
            Justification justification211 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties215.Append(justification211);

            paragraph224.Append(paragraphProperties215);

            tableCell204.Append(tableCellProperties204);
            tableCell204.Append(paragraph224);

            TableCell tableCell205 = new TableCell();

            TableCellProperties tableCellProperties205 = new TableCellProperties();
            TableCellWidth tableCellWidth205 = new TableCellWidth() { Width = "808", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders203 = new TableCellBorders();
            TopBorder topBorder202 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder193 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder208 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder193 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders203.Append(topBorder202);
            tableCellBorders203.Append(leftBorder193);
            tableCellBorders203.Append(bottomBorder208);
            tableCellBorders203.Append(rightBorder193);
            Shading shading205 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties205.Append(tableCellWidth205);
            tableCellProperties205.Append(tableCellBorders203);
            tableCellProperties205.Append(shading205);

            Paragraph paragraph225 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties216 = new ParagraphProperties();
            Justification justification212 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties216.Append(justification212);

            paragraph225.Append(paragraphProperties216);

            tableCell205.Append(tableCellProperties205);
            tableCell205.Append(paragraph225);

            TableCell tableCell206 = new TableCell();

            TableCellProperties tableCellProperties206 = new TableCellProperties();
            TableCellWidth tableCellWidth206 = new TableCellWidth() { Width = "900", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders204 = new TableCellBorders();
            TopBorder topBorder203 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder194 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder209 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder194 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders204.Append(topBorder203);
            tableCellBorders204.Append(leftBorder194);
            tableCellBorders204.Append(bottomBorder209);
            tableCellBorders204.Append(rightBorder194);
            Shading shading206 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties206.Append(tableCellWidth206);
            tableCellProperties206.Append(tableCellBorders204);
            tableCellProperties206.Append(shading206);

            Paragraph paragraph226 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties217 = new ParagraphProperties();
            Justification justification213 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties217.Append(justification213);

            paragraph226.Append(paragraphProperties217);

            tableCell206.Append(tableCellProperties206);
            tableCell206.Append(paragraph226);

            TableCell tableCell207 = new TableCell();

            TableCellProperties tableCellProperties207 = new TableCellProperties();
            TableCellWidth tableCellWidth207 = new TableCellWidth() { Width = "900", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders205 = new TableCellBorders();
            TopBorder topBorder204 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder195 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder210 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder195 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders205.Append(topBorder204);
            tableCellBorders205.Append(leftBorder195);
            tableCellBorders205.Append(bottomBorder210);
            tableCellBorders205.Append(rightBorder195);
            Shading shading207 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties207.Append(tableCellWidth207);
            tableCellProperties207.Append(tableCellBorders205);
            tableCellProperties207.Append(shading207);

            Paragraph paragraph227 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties218 = new ParagraphProperties();
            Justification justification214 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties218.Append(justification214);

            paragraph227.Append(paragraphProperties218);

            tableCell207.Append(tableCellProperties207);
            tableCell207.Append(paragraph227);

            TableCell tableCell208 = new TableCell();

            TableCellProperties tableCellProperties208 = new TableCellProperties();
            TableCellWidth tableCellWidth208 = new TableCellWidth() { Width = "900", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders206 = new TableCellBorders();
            TopBorder topBorder205 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder196 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder211 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder196 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders206.Append(topBorder205);
            tableCellBorders206.Append(leftBorder196);
            tableCellBorders206.Append(bottomBorder211);
            tableCellBorders206.Append(rightBorder196);
            Shading shading208 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties208.Append(tableCellWidth208);
            tableCellProperties208.Append(tableCellBorders206);
            tableCellProperties208.Append(shading208);

            Paragraph paragraph228 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties219 = new ParagraphProperties();
            Justification justification215 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties219.Append(justification215);

            paragraph228.Append(paragraphProperties219);

            tableCell208.Append(tableCellProperties208);
            tableCell208.Append(paragraph228);

            TableCell tableCell209 = new TableCell();

            TableCellProperties tableCellProperties209 = new TableCellProperties();
            TableCellWidth tableCellWidth209 = new TableCellWidth() { Width = "900", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders207 = new TableCellBorders();
            TopBorder topBorder206 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder197 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder212 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder197 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders207.Append(topBorder206);
            tableCellBorders207.Append(leftBorder197);
            tableCellBorders207.Append(bottomBorder212);
            tableCellBorders207.Append(rightBorder197);
            Shading shading209 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties209.Append(tableCellWidth209);
            tableCellProperties209.Append(tableCellBorders207);
            tableCellProperties209.Append(shading209);

            Paragraph paragraph229 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties220 = new ParagraphProperties();
            Justification justification216 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties220.Append(justification216);

            paragraph229.Append(paragraphProperties220);

            tableCell209.Append(tableCellProperties209);
            tableCell209.Append(paragraph229);

            TableCell tableCell210 = new TableCell();

            TableCellProperties tableCellProperties210 = new TableCellProperties();
            TableCellWidth tableCellWidth210 = new TableCellWidth() { Width = "900", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders208 = new TableCellBorders();
            TopBorder topBorder207 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder198 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder213 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder198 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders208.Append(topBorder207);
            tableCellBorders208.Append(leftBorder198);
            tableCellBorders208.Append(bottomBorder213);
            tableCellBorders208.Append(rightBorder198);
            Shading shading210 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties210.Append(tableCellWidth210);
            tableCellProperties210.Append(tableCellBorders208);
            tableCellProperties210.Append(shading210);

            Paragraph paragraph230 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties221 = new ParagraphProperties();
            Justification justification217 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties221.Append(justification217);

            paragraph230.Append(paragraphProperties221);

            tableCell210.Append(tableCellProperties210);
            tableCell210.Append(paragraph230);

            TableCell tableCell211 = new TableCell();

            TableCellProperties tableCellProperties211 = new TableCellProperties();
            TableCellWidth tableCellWidth211 = new TableCellWidth() { Width = "1800", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders209 = new TableCellBorders();
            TopBorder topBorder208 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder199 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder214 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder199 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders209.Append(topBorder208);
            tableCellBorders209.Append(leftBorder199);
            tableCellBorders209.Append(bottomBorder214);
            tableCellBorders209.Append(rightBorder199);
            Shading shading211 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties211.Append(tableCellWidth211);
            tableCellProperties211.Append(tableCellBorders209);
            tableCellProperties211.Append(shading211);

            Paragraph paragraph231 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties222 = new ParagraphProperties();
            Justification justification218 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties222.Append(justification218);

            paragraph231.Append(paragraphProperties222);

            tableCell211.Append(tableCellProperties211);
            tableCell211.Append(paragraph231);

            tableRow37.Append(tableRowProperties16);
            tableRow37.Append(tableCell202);
            tableRow37.Append(tableCell203);
            tableRow37.Append(tableCell204);
            tableRow37.Append(tableCell205);
            tableRow37.Append(tableCell206);
            tableRow37.Append(tableCell207);
            tableRow37.Append(tableCell208);
            tableRow37.Append(tableCell209);
            tableRow37.Append(tableCell210);
            tableRow37.Append(tableCell211);

            table6.Append(tableProperties6);
            table6.Append(tableGrid6);
            table6.Append(tableRow33);
            table6.Append(tableRow34);
            table6.Append(tableRow35);
            table6.Append(tableRow36);
            table6.Append(tableRow37);

            Paragraph paragraph232 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "006E25E8", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties223 = new ParagraphProperties();
            Justification justification219 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties223.Append(justification219);

            paragraph232.Append(paragraphProperties223);

            Table table7 = new Table();

            TableProperties tableProperties7 = new TableProperties();
            TableWidth tableWidth7 = new TableWidth() { Width = "0", Type = TableWidthUnitValues.Auto };
            TableIndentation tableIndentation3 = new TableIndentation() { Width = 828, Type = TableWidthUnitValues.Dxa };

            TableBorders tableBorders6 = new TableBorders();
            TopBorder topBorder209 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder200 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder215 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder200 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            InsideHorizontalBorder insideHorizontalBorder5 = new InsideHorizontalBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            InsideVerticalBorder insideVerticalBorder5 = new InsideVerticalBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableBorders6.Append(topBorder209);
            tableBorders6.Append(leftBorder200);
            tableBorders6.Append(bottomBorder215);
            tableBorders6.Append(rightBorder200);
            tableBorders6.Append(insideHorizontalBorder5);
            tableBorders6.Append(insideVerticalBorder5);
            TableLook tableLook7 = new TableLook() { Val = "01E0", FirstRow = true, LastRow = true, FirstColumn = true, LastColumn = true, NoHorizontalBand = false, NoVerticalBand = false };

            tableProperties7.Append(tableWidth7);
            tableProperties7.Append(tableIndentation3);
            tableProperties7.Append(tableBorders6);
            tableProperties7.Append(tableLook7);

            TableGrid tableGrid7 = new TableGrid();
            GridColumn gridColumn54 = new GridColumn() { Width = "4320" };
            GridColumn gridColumn55 = new GridColumn() { Width = "2386" };
            GridColumn gridColumn56 = new GridColumn() { Width = "4094" };
            GridColumn gridColumn57 = new GridColumn() { Width = "1980" };

            tableGrid7.Append(gridColumn54);
            tableGrid7.Append(gridColumn55);
            tableGrid7.Append(gridColumn56);
            tableGrid7.Append(gridColumn57);

            TableRow tableRow38 = new TableRow() { RsidTableRowMarkRevision = "00E96696", RsidTableRowAddition = "006E25E8", RsidTableRowProperties = "00E96696" };

            TableRowProperties tableRowProperties17 = new TableRowProperties();
            TableRowHeight tableRowHeight3 = new TableRowHeight() { Val = (UInt32Value)537U };

            tableRowProperties17.Append(tableRowHeight3);

            TableCell tableCell212 = new TableCell();

            TableCellProperties tableCellProperties212 = new TableCellProperties();
            TableCellWidth tableCellWidth212 = new TableCellWidth() { Width = "6706", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan63 = new GridSpan() { Val = 2 };

            TableCellBorders tableCellBorders210 = new TableCellBorders();
            TopBorder topBorder210 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder201 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder216 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder201 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders210.Append(topBorder210);
            tableCellBorders210.Append(leftBorder201);
            tableCellBorders210.Append(bottomBorder216);
            tableCellBorders210.Append(rightBorder201);
            Shading shading212 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            TableCellVerticalAlignment tableCellVerticalAlignment16 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };
            HideMark hideMark38 = new HideMark();

            tableCellProperties212.Append(tableCellWidth212);
            tableCellProperties212.Append(gridSpan63);
            tableCellProperties212.Append(tableCellBorders210);
            tableCellProperties212.Append(shading212);
            tableCellProperties212.Append(tableCellVerticalAlignment16);
            tableCellProperties212.Append(hideMark38);

            Paragraph paragraph233 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties224 = new ParagraphProperties();
            Justification justification220 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties224.Append(justification220);

            Run run113 = new Run();
            Text text112 = new Text();
            text112.Text = "Поощрения";

            run113.Append(text112);

            paragraph233.Append(paragraphProperties224);
            paragraph233.Append(run113);

            tableCell212.Append(tableCellProperties212);
            tableCell212.Append(paragraph233);

            TableCell tableCell213 = new TableCell();

            TableCellProperties tableCellProperties213 = new TableCellProperties();
            TableCellWidth tableCellWidth213 = new TableCellWidth() { Width = "6074", Type = TableWidthUnitValues.Dxa };
            GridSpan gridSpan64 = new GridSpan() { Val = 2 };

            TableCellBorders tableCellBorders211 = new TableCellBorders();
            TopBorder topBorder211 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder202 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder217 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder202 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders211.Append(topBorder211);
            tableCellBorders211.Append(leftBorder202);
            tableCellBorders211.Append(bottomBorder217);
            tableCellBorders211.Append(rightBorder202);
            Shading shading213 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            TableCellVerticalAlignment tableCellVerticalAlignment17 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };
            HideMark hideMark39 = new HideMark();

            tableCellProperties213.Append(tableCellWidth213);
            tableCellProperties213.Append(gridSpan64);
            tableCellProperties213.Append(tableCellBorders211);
            tableCellProperties213.Append(shading213);
            tableCellProperties213.Append(tableCellVerticalAlignment17);
            tableCellProperties213.Append(hideMark39);

            Paragraph paragraph234 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties225 = new ParagraphProperties();
            Justification justification221 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties225.Append(justification221);

            Run run114 = new Run();
            Text text113 = new Text();
            text113.Text = "Взыскания";

            run114.Append(text113);

            paragraph234.Append(paragraphProperties225);
            paragraph234.Append(run114);

            tableCell213.Append(tableCellProperties213);
            tableCell213.Append(paragraph234);

            tableRow38.Append(tableRowProperties17);
            tableRow38.Append(tableCell212);
            tableRow38.Append(tableCell213);

            TableRow tableRow39 = new TableRow() { RsidTableRowMarkRevision = "00E96696", RsidTableRowAddition = "006E25E8", RsidTableRowProperties = "00E96696" };

            TableCell tableCell214 = new TableCell();

            TableCellProperties tableCellProperties214 = new TableCellProperties();
            TableCellWidth tableCellWidth214 = new TableCellWidth() { Width = "4320", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders212 = new TableCellBorders();
            TopBorder topBorder212 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder203 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder218 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder203 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders212.Append(topBorder212);
            tableCellBorders212.Append(leftBorder203);
            tableCellBorders212.Append(bottomBorder218);
            tableCellBorders212.Append(rightBorder203);
            Shading shading214 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            TableCellVerticalAlignment tableCellVerticalAlignment18 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };
            HideMark hideMark40 = new HideMark();

            tableCellProperties214.Append(tableCellWidth214);
            tableCellProperties214.Append(tableCellBorders212);
            tableCellProperties214.Append(shading214);
            tableCellProperties214.Append(tableCellVerticalAlignment18);
            tableCellProperties214.Append(hideMark40);

            Paragraph paragraph235 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties226 = new ParagraphProperties();
            Justification justification222 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties226.Append(justification222);

            Run run115 = new Run();
            Text text114 = new Text();
            text114.Text = "Характер";

            run115.Append(text114);

            paragraph235.Append(paragraphProperties226);
            paragraph235.Append(run115);

            tableCell214.Append(tableCellProperties214);
            tableCell214.Append(paragraph235);

            TableCell tableCell215 = new TableCell();

            TableCellProperties tableCellProperties215 = new TableCellProperties();
            TableCellWidth tableCellWidth215 = new TableCellWidth() { Width = "2386", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders213 = new TableCellBorders();
            TopBorder topBorder213 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder204 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder219 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder204 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders213.Append(topBorder213);
            tableCellBorders213.Append(leftBorder204);
            tableCellBorders213.Append(bottomBorder219);
            tableCellBorders213.Append(rightBorder204);
            Shading shading215 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            TableCellVerticalAlignment tableCellVerticalAlignment19 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };
            HideMark hideMark41 = new HideMark();

            tableCellProperties215.Append(tableCellWidth215);
            tableCellProperties215.Append(tableCellBorders213);
            tableCellProperties215.Append(shading215);
            tableCellProperties215.Append(tableCellVerticalAlignment19);
            tableCellProperties215.Append(hideMark41);

            Paragraph paragraph236 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties227 = new ParagraphProperties();
            Justification justification223 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties227.Append(justification223);

            Run run116 = new Run();
            Text text115 = new Text();
            text115.Text = "Дата и номер приказа";

            run116.Append(text115);

            paragraph236.Append(paragraphProperties227);
            paragraph236.Append(run116);

            tableCell215.Append(tableCellProperties215);
            tableCell215.Append(paragraph236);

            TableCell tableCell216 = new TableCell();

            TableCellProperties tableCellProperties216 = new TableCellProperties();
            TableCellWidth tableCellWidth216 = new TableCellWidth() { Width = "4094", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders214 = new TableCellBorders();
            TopBorder topBorder214 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder205 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder220 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder205 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders214.Append(topBorder214);
            tableCellBorders214.Append(leftBorder205);
            tableCellBorders214.Append(bottomBorder220);
            tableCellBorders214.Append(rightBorder205);
            Shading shading216 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            TableCellVerticalAlignment tableCellVerticalAlignment20 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };
            HideMark hideMark42 = new HideMark();

            tableCellProperties216.Append(tableCellWidth216);
            tableCellProperties216.Append(tableCellBorders214);
            tableCellProperties216.Append(shading216);
            tableCellProperties216.Append(tableCellVerticalAlignment20);
            tableCellProperties216.Append(hideMark42);

            Paragraph paragraph237 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties228 = new ParagraphProperties();
            Justification justification224 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties228.Append(justification224);

            Run run117 = new Run();
            Text text116 = new Text();
            text116.Text = "Характер";

            run117.Append(text116);

            paragraph237.Append(paragraphProperties228);
            paragraph237.Append(run117);

            tableCell216.Append(tableCellProperties216);
            tableCell216.Append(paragraph237);

            TableCell tableCell217 = new TableCell();

            TableCellProperties tableCellProperties217 = new TableCellProperties();
            TableCellWidth tableCellWidth217 = new TableCellWidth() { Width = "1980", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders215 = new TableCellBorders();
            TopBorder topBorder215 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder206 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder221 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder206 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders215.Append(topBorder215);
            tableCellBorders215.Append(leftBorder206);
            tableCellBorders215.Append(bottomBorder221);
            tableCellBorders215.Append(rightBorder206);
            Shading shading217 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            TableCellVerticalAlignment tableCellVerticalAlignment21 = new TableCellVerticalAlignment() { Val = TableVerticalAlignmentValues.Center };
            HideMark hideMark43 = new HideMark();

            tableCellProperties217.Append(tableCellWidth217);
            tableCellProperties217.Append(tableCellBorders215);
            tableCellProperties217.Append(shading217);
            tableCellProperties217.Append(tableCellVerticalAlignment21);
            tableCellProperties217.Append(hideMark43);

            Paragraph paragraph238 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties229 = new ParagraphProperties();
            Justification justification225 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties229.Append(justification225);

            Run run118 = new Run();
            Text text117 = new Text();
            text117.Text = "Дата и номер приказа";

            run118.Append(text117);

            paragraph238.Append(paragraphProperties229);
            paragraph238.Append(run118);

            tableCell217.Append(tableCellProperties217);
            tableCell217.Append(paragraph238);

            tableRow39.Append(tableCell214);
            tableRow39.Append(tableCell215);
            tableRow39.Append(tableCell216);
            tableRow39.Append(tableCell217);

            TableRow tableRow40 = new TableRow() { RsidTableRowMarkRevision = "00E96696", RsidTableRowAddition = "006E25E8", RsidTableRowProperties = "00E96696" };

            TableRowProperties tableRowProperties18 = new TableRowProperties();
            TableRowHeight tableRowHeight4 = new TableRowHeight() { Val = (UInt32Value)1575U };

            tableRowProperties18.Append(tableRowHeight4);

            TableCell tableCell218 = new TableCell();

            TableCellProperties tableCellProperties218 = new TableCellProperties();
            TableCellWidth tableCellWidth218 = new TableCellWidth() { Width = "4320", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders216 = new TableCellBorders();
            TopBorder topBorder216 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder207 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder222 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder207 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders216.Append(topBorder216);
            tableCellBorders216.Append(leftBorder207);
            tableCellBorders216.Append(bottomBorder222);
            tableCellBorders216.Append(rightBorder207);
            Shading shading218 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties218.Append(tableCellWidth218);
            tableCellProperties218.Append(tableCellBorders216);
            tableCellProperties218.Append(shading218);

            Paragraph paragraph239 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties230 = new ParagraphProperties();
            Justification justification226 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties230.Append(justification226);

            paragraph239.Append(paragraphProperties230);

            tableCell218.Append(tableCellProperties218);
            tableCell218.Append(paragraph239);

            TableCell tableCell219 = new TableCell();

            TableCellProperties tableCellProperties219 = new TableCellProperties();
            TableCellWidth tableCellWidth219 = new TableCellWidth() { Width = "2386", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders217 = new TableCellBorders();
            TopBorder topBorder217 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder208 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder223 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder208 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders217.Append(topBorder217);
            tableCellBorders217.Append(leftBorder208);
            tableCellBorders217.Append(bottomBorder223);
            tableCellBorders217.Append(rightBorder208);
            Shading shading219 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties219.Append(tableCellWidth219);
            tableCellProperties219.Append(tableCellBorders217);
            tableCellProperties219.Append(shading219);

            Paragraph paragraph240 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties231 = new ParagraphProperties();
            Justification justification227 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties231.Append(justification227);

            paragraph240.Append(paragraphProperties231);

            tableCell219.Append(tableCellProperties219);
            tableCell219.Append(paragraph240);

            TableCell tableCell220 = new TableCell();

            TableCellProperties tableCellProperties220 = new TableCellProperties();
            TableCellWidth tableCellWidth220 = new TableCellWidth() { Width = "4094", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders218 = new TableCellBorders();
            TopBorder topBorder218 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder209 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder224 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder209 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders218.Append(topBorder218);
            tableCellBorders218.Append(leftBorder209);
            tableCellBorders218.Append(bottomBorder224);
            tableCellBorders218.Append(rightBorder209);
            Shading shading220 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties220.Append(tableCellWidth220);
            tableCellProperties220.Append(tableCellBorders218);
            tableCellProperties220.Append(shading220);

            Paragraph paragraph241 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties232 = new ParagraphProperties();
            Justification justification228 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties232.Append(justification228);

            paragraph241.Append(paragraphProperties232);

            tableCell220.Append(tableCellProperties220);
            tableCell220.Append(paragraph241);

            TableCell tableCell221 = new TableCell();

            TableCellProperties tableCellProperties221 = new TableCellProperties();
            TableCellWidth tableCellWidth221 = new TableCellWidth() { Width = "1980", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders219 = new TableCellBorders();
            TopBorder topBorder219 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder210 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder225 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder210 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableCellBorders219.Append(topBorder219);
            tableCellBorders219.Append(leftBorder210);
            tableCellBorders219.Append(bottomBorder225);
            tableCellBorders219.Append(rightBorder210);
            Shading shading221 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties221.Append(tableCellWidth221);
            tableCellProperties221.Append(tableCellBorders219);
            tableCellProperties221.Append(shading221);

            Paragraph paragraph242 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties233 = new ParagraphProperties();
            Justification justification229 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties233.Append(justification229);

            paragraph242.Append(paragraphProperties233);

            tableCell221.Append(tableCellProperties221);
            tableCell221.Append(paragraph242);

            tableRow40.Append(tableRowProperties18);
            tableRow40.Append(tableCell218);
            tableRow40.Append(tableCell219);
            tableRow40.Append(tableCell220);
            tableRow40.Append(tableCell221);

            table7.Append(tableProperties7);
            table7.Append(tableGrid7);
            table7.Append(tableRow38);
            table7.Append(tableRow39);
            table7.Append(tableRow40);

            Paragraph paragraph243 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "006E25E8", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties234 = new ParagraphProperties();
            Justification justification230 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties234.Append(justification230);

            paragraph243.Append(paragraphProperties234);

            Table table8 = new Table();

            TableProperties tableProperties8 = new TableProperties();
            TableWidth tableWidth8 = new TableWidth() { Width = "0", Type = TableWidthUnitValues.Auto };
            TableJustification tableJustification16 = new TableJustification() { Val = TableRowAlignmentValues.Center };

            TableBorders tableBorders7 = new TableBorders();
            TopBorder topBorder220 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder211 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder226 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder211 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            InsideHorizontalBorder insideHorizontalBorder6 = new InsideHorizontalBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            InsideVerticalBorder insideVerticalBorder6 = new InsideVerticalBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableBorders7.Append(topBorder220);
            tableBorders7.Append(leftBorder211);
            tableBorders7.Append(bottomBorder226);
            tableBorders7.Append(rightBorder211);
            tableBorders7.Append(insideHorizontalBorder6);
            tableBorders7.Append(insideVerticalBorder6);
            TableLook tableLook8 = new TableLook() { Val = "01E0", FirstRow = true, LastRow = true, FirstColumn = true, LastColumn = true, NoHorizontalBand = false, NoVerticalBand = false };

            tableProperties8.Append(tableWidth8);
            tableProperties8.Append(tableJustification16);
            tableProperties8.Append(tableBorders7);
            tableProperties8.Append(tableLook8);

            TableGrid tableGrid8 = new TableGrid();
            GridColumn gridColumn58 = new GridColumn() { Width = "3816" };
            GridColumn gridColumn59 = new GridColumn() { Width = "4742" };
            GridColumn gridColumn60 = new GridColumn() { Width = "2890" };

            tableGrid8.Append(gridColumn58);
            tableGrid8.Append(gridColumn59);
            tableGrid8.Append(gridColumn60);

            TableRow tableRow41 = new TableRow() { RsidTableRowMarkRevision = "00E96696", RsidTableRowAddition = "006E25E8", RsidTableRowProperties = "00E96696" };

            TableRowProperties tableRowProperties19 = new TableRowProperties();
            TableJustification tableJustification17 = new TableJustification() { Val = TableRowAlignmentValues.Center };

            tableRowProperties19.Append(tableJustification17);

            TableCell tableCell222 = new TableCell();

            TableCellProperties tableCellProperties222 = new TableCellProperties();
            TableCellWidth tableCellWidth222 = new TableCellWidth() { Width = "3816", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders220 = new TableCellBorders();
            TopBorder topBorder221 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder212 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder227 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder212 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders220.Append(topBorder221);
            tableCellBorders220.Append(leftBorder212);
            tableCellBorders220.Append(bottomBorder227);
            tableCellBorders220.Append(rightBorder212);
            Shading shading222 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            HideMark hideMark44 = new HideMark();

            tableCellProperties222.Append(tableCellWidth222);
            tableCellProperties222.Append(tableCellBorders220);
            tableCellProperties222.Append(shading222);
            tableCellProperties222.Append(hideMark44);

            Paragraph paragraph244 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties235 = new ParagraphProperties();
            Justification justification231 = new Justification() { Val = JustificationValues.Right };

            paragraphProperties235.Append(justification231);

            Run run119 = new Run();
            Text text118 = new Text();
            text118.Text = "Начальник учебной части";

            run119.Append(text118);

            paragraph244.Append(paragraphProperties235);
            paragraph244.Append(run119);

            tableCell222.Append(tableCellProperties222);
            tableCell222.Append(paragraph244);

            TableCell tableCell223 = new TableCell();

            TableCellProperties tableCellProperties223 = new TableCellProperties();
            TableCellWidth tableCellWidth223 = new TableCellWidth() { Width = "4742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders221 = new TableCellBorders();
            TopBorder topBorder222 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder213 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder228 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder213 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders221.Append(topBorder222);
            tableCellBorders221.Append(leftBorder213);
            tableCellBorders221.Append(bottomBorder228);
            tableCellBorders221.Append(rightBorder213);
            Shading shading223 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties223.Append(tableCellWidth223);
            tableCellProperties223.Append(tableCellBorders221);
            tableCellProperties223.Append(shading223);

            Paragraph paragraph245 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties236 = new ParagraphProperties();
            Justification justification232 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties34 = new ParagraphMarkRunProperties();
            Languages languages42 = new Languages() { Val = "en-US" };

            paragraphMarkRunProperties34.Append(languages42);

            paragraphProperties236.Append(justification232);
            paragraphProperties236.Append(paragraphMarkRunProperties34);
            BookmarkStart bookmarkStart2 = new BookmarkStart() { Name = "bkNUduty", Id = "1" };
            BookmarkEnd bookmarkEnd2 = new BookmarkEnd() { Id = "1" };

            paragraph245.Append(paragraphProperties236);
            paragraph245.Append(bookmarkStart2);
            paragraph245.Append(bookmarkEnd2);

            tableCell223.Append(tableCellProperties223);
            tableCell223.Append(paragraph245);

            TableCell tableCell224 = new TableCell();

            TableCellProperties tableCellProperties224 = new TableCellProperties();
            TableCellWidth tableCellWidth224 = new TableCellWidth() { Width = "2890", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders222 = new TableCellBorders();
            TopBorder topBorder223 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder214 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder229 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder214 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders222.Append(topBorder223);
            tableCellBorders222.Append(leftBorder214);
            tableCellBorders222.Append(bottomBorder229);
            tableCellBorders222.Append(rightBorder214);
            Shading shading224 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties224.Append(tableCellWidth224);
            tableCellProperties224.Append(tableCellBorders222);
            tableCellProperties224.Append(shading224);

            Paragraph paragraph246 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties237 = new ParagraphProperties();
            Justification justification233 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties237.Append(justification233);
            BookmarkStart bookmarkStart3 = new BookmarkStart() { Name = "bkNUName", Id = "2" };
            BookmarkEnd bookmarkEnd3 = new BookmarkEnd() { Id = "2" };

            paragraph246.Append(paragraphProperties237);
            paragraph246.Append(bookmarkStart3);
            paragraph246.Append(bookmarkEnd3);

            tableCell224.Append(tableCellProperties224);
            tableCell224.Append(paragraph246);

            tableRow41.Append(tableRowProperties19);
            tableRow41.Append(tableCell222);
            tableRow41.Append(tableCell223);
            tableRow41.Append(tableCell224);

            TableRow tableRow42 = new TableRow() { RsidTableRowMarkRevision = "00E96696", RsidTableRowAddition = "006E25E8", RsidTableRowProperties = "00E96696" };

            TableRowProperties tableRowProperties20 = new TableRowProperties();
            TableRowHeight tableRowHeight5 = new TableRowHeight() { Val = (UInt32Value)170U };
            TableJustification tableJustification18 = new TableJustification() { Val = TableRowAlignmentValues.Center };

            tableRowProperties20.Append(tableRowHeight5);
            tableRowProperties20.Append(tableJustification18);

            TableCell tableCell225 = new TableCell();

            TableCellProperties tableCellProperties225 = new TableCellProperties();
            TableCellWidth tableCellWidth225 = new TableCellWidth() { Width = "3816", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders223 = new TableCellBorders();
            TopBorder topBorder224 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder215 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder230 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder215 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders223.Append(topBorder224);
            tableCellBorders223.Append(leftBorder215);
            tableCellBorders223.Append(bottomBorder230);
            tableCellBorders223.Append(rightBorder215);
            Shading shading225 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties225.Append(tableCellWidth225);
            tableCellProperties225.Append(tableCellBorders223);
            tableCellProperties225.Append(shading225);

            Paragraph paragraph247 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties238 = new ParagraphProperties();
            Justification justification234 = new Justification() { Val = JustificationValues.Right };

            ParagraphMarkRunProperties paragraphMarkRunProperties35 = new ParagraphMarkRunProperties();
            FontSize fontSize63 = new FontSize() { Val = "14" };
            FontSizeComplexScript fontSizeComplexScript63 = new FontSizeComplexScript() { Val = "14" };

            paragraphMarkRunProperties35.Append(fontSize63);
            paragraphMarkRunProperties35.Append(fontSizeComplexScript63);

            paragraphProperties238.Append(justification234);
            paragraphProperties238.Append(paragraphMarkRunProperties35);

            paragraph247.Append(paragraphProperties238);

            tableCell225.Append(tableCellProperties225);
            tableCell225.Append(paragraph247);

            TableCell tableCell226 = new TableCell();

            TableCellProperties tableCellProperties226 = new TableCellProperties();
            TableCellWidth tableCellWidth226 = new TableCellWidth() { Width = "4742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders224 = new TableCellBorders();
            TopBorder topBorder225 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder216 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder231 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder216 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders224.Append(topBorder225);
            tableCellBorders224.Append(leftBorder216);
            tableCellBorders224.Append(bottomBorder231);
            tableCellBorders224.Append(rightBorder216);
            Shading shading226 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            HideMark hideMark45 = new HideMark();

            tableCellProperties226.Append(tableCellWidth226);
            tableCellProperties226.Append(tableCellBorders224);
            tableCellProperties226.Append(shading226);
            tableCellProperties226.Append(hideMark45);

            Paragraph paragraph248 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties239 = new ParagraphProperties();
            Justification justification235 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties36 = new ParagraphMarkRunProperties();
            FontSize fontSize64 = new FontSize() { Val = "14" };
            FontSizeComplexScript fontSizeComplexScript64 = new FontSizeComplexScript() { Val = "14" };

            paragraphMarkRunProperties36.Append(fontSize64);
            paragraphMarkRunProperties36.Append(fontSizeComplexScript64);

            paragraphProperties239.Append(justification235);
            paragraphProperties239.Append(paragraphMarkRunProperties36);

            Run run120 = new Run() { RsidRunProperties = "00E96696" };

            RunProperties runProperties35 = new RunProperties();
            FontSize fontSize65 = new FontSize() { Val = "14" };
            FontSizeComplexScript fontSizeComplexScript65 = new FontSizeComplexScript() { Val = "14" };

            runProperties35.Append(fontSize65);
            runProperties35.Append(fontSizeComplexScript65);
            Text text119 = new Text();
            text119.Text = "(воинское звание,подпись)";

            run120.Append(runProperties35);
            run120.Append(text119);

            paragraph248.Append(paragraphProperties239);
            paragraph248.Append(run120);

            tableCell226.Append(tableCellProperties226);
            tableCell226.Append(paragraph248);

            TableCell tableCell227 = new TableCell();

            TableCellProperties tableCellProperties227 = new TableCellProperties();
            TableCellWidth tableCellWidth227 = new TableCellWidth() { Width = "2890", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders225 = new TableCellBorders();
            TopBorder topBorder226 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder217 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder232 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder217 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders225.Append(topBorder226);
            tableCellBorders225.Append(leftBorder217);
            tableCellBorders225.Append(bottomBorder232);
            tableCellBorders225.Append(rightBorder217);
            Shading shading227 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties227.Append(tableCellWidth227);
            tableCellProperties227.Append(tableCellBorders225);
            tableCellProperties227.Append(shading227);

            Paragraph paragraph249 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties240 = new ParagraphProperties();
            Justification justification236 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties37 = new ParagraphMarkRunProperties();
            FontSize fontSize66 = new FontSize() { Val = "14" };
            FontSizeComplexScript fontSizeComplexScript66 = new FontSizeComplexScript() { Val = "14" };

            paragraphMarkRunProperties37.Append(fontSize66);
            paragraphMarkRunProperties37.Append(fontSizeComplexScript66);

            paragraphProperties240.Append(justification236);
            paragraphProperties240.Append(paragraphMarkRunProperties37);

            paragraph249.Append(paragraphProperties240);

            tableCell227.Append(tableCellProperties227);
            tableCell227.Append(paragraph249);

            tableRow42.Append(tableRowProperties20);
            tableRow42.Append(tableCell225);
            tableRow42.Append(tableCell226);
            tableRow42.Append(tableCell227);

            TableRow tableRow43 = new TableRow() { RsidTableRowMarkRevision = "00E96696", RsidTableRowAddition = "006E25E8", RsidTableRowProperties = "00E96696" };

            TableRowProperties tableRowProperties21 = new TableRowProperties();
            TableJustification tableJustification19 = new TableJustification() { Val = TableRowAlignmentValues.Center };

            tableRowProperties21.Append(tableJustification19);

            TableCell tableCell228 = new TableCell();

            TableCellProperties tableCellProperties228 = new TableCellProperties();
            TableCellWidth tableCellWidth228 = new TableCellWidth() { Width = "3816", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders226 = new TableCellBorders();
            TopBorder topBorder227 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder218 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder233 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder218 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders226.Append(topBorder227);
            tableCellBorders226.Append(leftBorder218);
            tableCellBorders226.Append(bottomBorder233);
            tableCellBorders226.Append(rightBorder218);
            Shading shading228 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            HideMark hideMark46 = new HideMark();

            tableCellProperties228.Append(tableCellWidth228);
            tableCellProperties228.Append(tableCellBorders226);
            tableCellProperties228.Append(shading228);
            tableCellProperties228.Append(hideMark46);

            Paragraph paragraph250 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties241 = new ParagraphProperties();
            Justification justification237 = new Justification() { Val = JustificationValues.Right };

            paragraphProperties241.Append(justification237);

            Run run121 = new Run();
            Text text120 = new Text();
            text120.Text = "Ответственный преподаватель";

            run121.Append(text120);

            paragraph250.Append(paragraphProperties241);
            paragraph250.Append(run121);

            tableCell228.Append(tableCellProperties228);
            tableCell228.Append(paragraph250);

            TableCell tableCell229 = new TableCell();

            TableCellProperties tableCellProperties229 = new TableCellProperties();
            TableCellWidth tableCellWidth229 = new TableCellWidth() { Width = "4742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders227 = new TableCellBorders();
            TopBorder topBorder228 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder219 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder234 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder219 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders227.Append(topBorder228);
            tableCellBorders227.Append(leftBorder219);
            tableCellBorders227.Append(bottomBorder234);
            tableCellBorders227.Append(rightBorder219);
            Shading shading229 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties229.Append(tableCellWidth229);
            tableCellProperties229.Append(tableCellBorders227);
            tableCellProperties229.Append(shading229);

            Paragraph paragraph251 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties242 = new ParagraphProperties();
            Justification justification238 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties38 = new ParagraphMarkRunProperties();
            Languages languages43 = new Languages() { Val = "en-US" };

            paragraphMarkRunProperties38.Append(languages43);

            paragraphProperties242.Append(justification238);
            paragraphProperties242.Append(paragraphMarkRunProperties38);
            BookmarkStart bookmarkStart4 = new BookmarkStart() { Name = "bkOPduty", Id = "3" };
            BookmarkEnd bookmarkEnd4 = new BookmarkEnd() { Id = "3" };

            paragraph251.Append(paragraphProperties242);
            paragraph251.Append(bookmarkStart4);
            paragraph251.Append(bookmarkEnd4);

            tableCell229.Append(tableCellProperties229);
            tableCell229.Append(paragraph251);

            TableCell tableCell230 = new TableCell();

            TableCellProperties tableCellProperties230 = new TableCellProperties();
            TableCellWidth tableCellWidth230 = new TableCellWidth() { Width = "2890", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders228 = new TableCellBorders();
            TopBorder topBorder229 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder220 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder235 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder220 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders228.Append(topBorder229);
            tableCellBorders228.Append(leftBorder220);
            tableCellBorders228.Append(bottomBorder235);
            tableCellBorders228.Append(rightBorder220);
            Shading shading230 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties230.Append(tableCellWidth230);
            tableCellProperties230.Append(tableCellBorders228);
            tableCellProperties230.Append(shading230);

            Paragraph paragraph252 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties243 = new ParagraphProperties();
            Justification justification239 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties39 = new ParagraphMarkRunProperties();
            Languages languages44 = new Languages() { Val = "en-US" };

            paragraphMarkRunProperties39.Append(languages44);

            paragraphProperties243.Append(justification239);
            paragraphProperties243.Append(paragraphMarkRunProperties39);
            BookmarkStart bookmarkStart5 = new BookmarkStart() { Name = "bkOPname", Id = "4" };
            BookmarkEnd bookmarkEnd5 = new BookmarkEnd() { Id = "4" };

            paragraph252.Append(paragraphProperties243);
            paragraph252.Append(bookmarkStart5);
            paragraph252.Append(bookmarkEnd5);

            tableCell230.Append(tableCellProperties230);
            tableCell230.Append(paragraph252);

            tableRow43.Append(tableRowProperties21);
            tableRow43.Append(tableCell228);
            tableRow43.Append(tableCell229);
            tableRow43.Append(tableCell230);

            TableRow tableRow44 = new TableRow() { RsidTableRowMarkRevision = "00E96696", RsidTableRowAddition = "006E25E8", RsidTableRowProperties = "00E96696" };

            TableRowProperties tableRowProperties22 = new TableRowProperties();
            TableJustification tableJustification20 = new TableJustification() { Val = TableRowAlignmentValues.Center };

            tableRowProperties22.Append(tableJustification20);

            TableCell tableCell231 = new TableCell();

            TableCellProperties tableCellProperties231 = new TableCellProperties();
            TableCellWidth tableCellWidth231 = new TableCellWidth() { Width = "3816", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders229 = new TableCellBorders();
            TopBorder topBorder230 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder221 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder236 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder221 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders229.Append(topBorder230);
            tableCellBorders229.Append(leftBorder221);
            tableCellBorders229.Append(bottomBorder236);
            tableCellBorders229.Append(rightBorder221);
            Shading shading231 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties231.Append(tableCellWidth231);
            tableCellProperties231.Append(tableCellBorders229);
            tableCellProperties231.Append(shading231);

            Paragraph paragraph253 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties244 = new ParagraphProperties();
            Justification justification240 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties244.Append(justification240);

            paragraph253.Append(paragraphProperties244);

            tableCell231.Append(tableCellProperties231);
            tableCell231.Append(paragraph253);

            TableCell tableCell232 = new TableCell();

            TableCellProperties tableCellProperties232 = new TableCellProperties();
            TableCellWidth tableCellWidth232 = new TableCellWidth() { Width = "4742", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders230 = new TableCellBorders();
            TopBorder topBorder231 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder222 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder237 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder222 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders230.Append(topBorder231);
            tableCellBorders230.Append(leftBorder222);
            tableCellBorders230.Append(bottomBorder237);
            tableCellBorders230.Append(rightBorder222);
            Shading shading232 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };
            HideMark hideMark47 = new HideMark();

            tableCellProperties232.Append(tableCellWidth232);
            tableCellProperties232.Append(tableCellBorders230);
            tableCellProperties232.Append(shading232);
            tableCellProperties232.Append(hideMark47);

            Paragraph paragraph254 = new Paragraph() { RsidParagraphMarkRevision = "00E96696", RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties245 = new ParagraphProperties();
            Justification justification241 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties40 = new ParagraphMarkRunProperties();
            FontSize fontSize67 = new FontSize() { Val = "14" };
            FontSizeComplexScript fontSizeComplexScript67 = new FontSizeComplexScript() { Val = "14" };

            paragraphMarkRunProperties40.Append(fontSize67);
            paragraphMarkRunProperties40.Append(fontSizeComplexScript67);

            paragraphProperties245.Append(justification241);
            paragraphProperties245.Append(paragraphMarkRunProperties40);

            Run run122 = new Run() { RsidRunProperties = "00E96696" };

            RunProperties runProperties36 = new RunProperties();
            FontSize fontSize68 = new FontSize() { Val = "14" };
            FontSizeComplexScript fontSizeComplexScript68 = new FontSizeComplexScript() { Val = "14" };

            runProperties36.Append(fontSize68);
            runProperties36.Append(fontSizeComplexScript68);
            Text text121 = new Text();
            text121.Text = "(воинское звание,подпись)";

            run122.Append(runProperties36);
            run122.Append(text121);

            paragraph254.Append(paragraphProperties245);
            paragraph254.Append(run122);

            tableCell232.Append(tableCellProperties232);
            tableCell232.Append(paragraph254);

            TableCell tableCell233 = new TableCell();

            TableCellProperties tableCellProperties233 = new TableCellProperties();
            TableCellWidth tableCellWidth233 = new TableCellWidth() { Width = "2890", Type = TableWidthUnitValues.Dxa };

            TableCellBorders tableCellBorders231 = new TableCellBorders();
            TopBorder topBorder232 = new TopBorder() { Val = BorderValues.Nil };
            LeftBorder leftBorder223 = new LeftBorder() { Val = BorderValues.Nil };
            BottomBorder bottomBorder238 = new BottomBorder() { Val = BorderValues.Nil };
            RightBorder rightBorder223 = new RightBorder() { Val = BorderValues.Nil };

            tableCellBorders231.Append(topBorder232);
            tableCellBorders231.Append(leftBorder223);
            tableCellBorders231.Append(bottomBorder238);
            tableCellBorders231.Append(rightBorder223);
            Shading shading233 = new Shading() { Val = ShadingPatternValues.Clear, Color = "auto", Fill = "auto" };

            tableCellProperties233.Append(tableCellWidth233);
            tableCellProperties233.Append(tableCellBorders231);
            tableCellProperties233.Append(shading233);

            Paragraph paragraph255 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "00E96696", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties246 = new ParagraphProperties();
            Justification justification242 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties246.Append(justification242);

            paragraph255.Append(paragraphProperties246);

            tableCell233.Append(tableCellProperties233);
            tableCell233.Append(paragraph255);

            tableRow44.Append(tableRowProperties22);
            tableRow44.Append(tableCell231);
            tableRow44.Append(tableCell232);
            tableRow44.Append(tableCell233);

            table8.Append(tableProperties8);
            table8.Append(tableGrid8);
            table8.Append(tableRow41);
            table8.Append(tableRow42);
            table8.Append(tableRow43);
            table8.Append(tableRow44);

            Paragraph paragraph256 = new Paragraph() { RsidParagraphAddition = "006E25E8", RsidParagraphProperties = "006E25E8", RsidRunAdditionDefault = "006E25E8" };

            ParagraphProperties paragraphProperties247 = new ParagraphProperties();
            Justification justification243 = new Justification() { Val = JustificationValues.Center };

            paragraphProperties247.Append(justification243);

            paragraph256.Append(paragraphProperties247);
            Paragraph paragraph257 = new Paragraph() { RsidParagraphMarkRevision = "004C4782", RsidParagraphAddition = "00F0258F", RsidParagraphProperties = "00763846", RsidRunAdditionDefault = "00F0258F" };

            SectionProperties sectionProperties1 = new SectionProperties() { RsidRPr = "004C4782", RsidR = "00F0258F", RsidSect = "00F0258F" };
            PageSize pageSize1 = new PageSize() { Width = (UInt32Value)16838U, Height = (UInt32Value)11906U, Orient = PageOrientationValues.Landscape };
            PageMargin pageMargin1 = new PageMargin() { Top = 340, Right = (UInt32Value)1134U, Bottom = 567, Left = (UInt32Value)1418U, Header = (UInt32Value)709U, Footer = (UInt32Value)709U, Gutter = (UInt32Value)0U };
            Columns columns1 = new Columns() { Space = "708" };
            DocGrid docGrid1 = new DocGrid() { LinePitch = 360 };

            sectionProperties1.Append(pageSize1);
            sectionProperties1.Append(pageMargin1);
            sectionProperties1.Append(columns1);
            sectionProperties1.Append(docGrid1);

            body1.Append(paragraph1);
            body1.Append(paragraph2);
            body1.Append(paragraph3);
            body1.Append(paragraph4);
            body1.Append(paragraph5);
            body1.Append(paragraph6);
            body1.Append(paragraph7);
            body1.Append(paragraph8);
            body1.Append(table1);
            body1.Append(paragraph11);
            body1.Append(paragraph12);
            body1.Append(paragraph13);
            body1.Append(table2);
            body1.Append(paragraph82);
            body1.Append(table3);
            body1.Append(paragraph97);
            body1.Append(table4);
            body1.Append(paragraph101);
            body1.Append(paragraph102);
            body1.Append(table5);
            body1.Append(paragraph187);
            body1.Append(paragraph188);
            body1.Append(table6);
            body1.Append(paragraph232);
            body1.Append(table7);
            body1.Append(paragraph243);
            body1.Append(table8);
            body1.Append(paragraph256);
            body1.Append(paragraph257);
            body1.Append(sectionProperties1);

            document1.Append(body1);

            mainDocumentPart1.Document = document1;
        }

        // Generates content of documentSettingsPart1.
        private void GenerateDocumentSettingsPart1Content(DocumentSettingsPart documentSettingsPart1)
        {
            Settings settings1 = new Settings() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 w15 w16se" } };
            settings1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            settings1.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
            settings1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            settings1.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
            settings1.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
            settings1.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
            settings1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            settings1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            settings1.AddNamespaceDeclaration("w15", "http://schemas.microsoft.com/office/word/2012/wordml");
            settings1.AddNamespaceDeclaration("w16se", "http://schemas.microsoft.com/office/word/2015/wordml/symex");
            settings1.AddNamespaceDeclaration("sl", "http://schemas.openxmlformats.org/schemaLibrary/2006/main");
            Zoom zoom1 = new Zoom() { Percent = "100" };
            ProofState proofState1 = new ProofState() { Grammar = ProofingStateValues.Clean };
            StylePaneFormatFilter stylePaneFormatFilter1 = new StylePaneFormatFilter() { Val = "3F01", AllStyles = true, CustomStyles = false, LatentStyles = false, StylesInUse = false, HeadingStyles = false, NumberingStyles = false, TableStyles = false, DirectFormattingOnRuns = true, DirectFormattingOnParagraphs = true, DirectFormattingOnNumbering = true, DirectFormattingOnTables = true, ClearFormatting = true, Top3HeadingStyles = true, VisibleStyles = false, AlternateStyleNames = false };
            DoNotTrackMoves doNotTrackMoves1 = new DoNotTrackMoves();
            DefaultTabStop defaultTabStop1 = new DefaultTabStop() { Val = 708 };
            NoPunctuationKerning noPunctuationKerning1 = new NoPunctuationKerning();
            CharacterSpacingControl characterSpacingControl1 = new CharacterSpacingControl() { Val = CharacterSpacingValues.DoNotCompress };

            Compatibility compatibility1 = new Compatibility();
            UseWord2002TableStyleRules useWord2002TableStyleRules1 = new UseWord2002TableStyleRules();
            GrowAutofit growAutofit1 = new GrowAutofit();
            UseNormalStyleForList useNormalStyleForList1 = new UseNormalStyleForList();
            DoNotUseIndentAsNumberingTabStop doNotUseIndentAsNumberingTabStop1 = new DoNotUseIndentAsNumberingTabStop();
            UseAltKinsokuLineBreakRules useAltKinsokuLineBreakRules1 = new UseAltKinsokuLineBreakRules();
            AllowSpaceOfSameStyleInTable allowSpaceOfSameStyleInTable1 = new AllowSpaceOfSameStyleInTable();
            DoNotSuppressIndentation doNotSuppressIndentation1 = new DoNotSuppressIndentation();
            DoNotAutofitConstrainedTables doNotAutofitConstrainedTables1 = new DoNotAutofitConstrainedTables();
            AutofitToFirstFixedWidthCell autofitToFirstFixedWidthCell1 = new AutofitToFirstFixedWidthCell();
            DisplayHangulFixedWidth displayHangulFixedWidth1 = new DisplayHangulFixedWidth();
            SplitPageBreakAndParagraphMark splitPageBreakAndParagraphMark1 = new SplitPageBreakAndParagraphMark();
            DoNotVerticallyAlignCellWithShape doNotVerticallyAlignCellWithShape1 = new DoNotVerticallyAlignCellWithShape();
            DoNotBreakConstrainedForcedTable doNotBreakConstrainedForcedTable1 = new DoNotBreakConstrainedForcedTable();
            DoNotVerticallyAlignInTextBox doNotVerticallyAlignInTextBox1 = new DoNotVerticallyAlignInTextBox();
            UseAnsiKerningPairs useAnsiKerningPairs1 = new UseAnsiKerningPairs();
            CachedColumnBalance cachedColumnBalance1 = new CachedColumnBalance();
            CompatibilitySetting compatibilitySetting1 = new CompatibilitySetting() { Name = CompatSettingNameValues.CompatibilityMode, Uri = "http://schemas.microsoft.com/office/word", Val = "11" };

            compatibility1.Append(useWord2002TableStyleRules1);
            compatibility1.Append(growAutofit1);
            compatibility1.Append(useNormalStyleForList1);
            compatibility1.Append(doNotUseIndentAsNumberingTabStop1);
            compatibility1.Append(useAltKinsokuLineBreakRules1);
            compatibility1.Append(allowSpaceOfSameStyleInTable1);
            compatibility1.Append(doNotSuppressIndentation1);
            compatibility1.Append(doNotAutofitConstrainedTables1);
            compatibility1.Append(autofitToFirstFixedWidthCell1);
            compatibility1.Append(displayHangulFixedWidth1);
            compatibility1.Append(splitPageBreakAndParagraphMark1);
            compatibility1.Append(doNotVerticallyAlignCellWithShape1);
            compatibility1.Append(doNotBreakConstrainedForcedTable1);
            compatibility1.Append(doNotVerticallyAlignInTextBox1);
            compatibility1.Append(useAnsiKerningPairs1);
            compatibility1.Append(cachedColumnBalance1);
            compatibility1.Append(compatibilitySetting1);

            Rsids rsids1 = new Rsids();
            RsidRoot rsidRoot1 = new RsidRoot() { Val = "005F2B37" };
            Rsid rsid1 = new Rsid() { Val = "000A7E3D" };
            Rsid rsid2 = new Rsid() { Val = "00133D07" };
            Rsid rsid3 = new Rsid() { Val = "00173B96" };
            Rsid rsid4 = new Rsid() { Val = "001A3DA5" };
            Rsid rsid5 = new Rsid() { Val = "00200F1F" };
            Rsid rsid6 = new Rsid() { Val = "00284D35" };
            Rsid rsid7 = new Rsid() { Val = "00284D9B" };
            Rsid rsid8 = new Rsid() { Val = "003C1EF1" };
            Rsid rsid9 = new Rsid() { Val = "004068DD" };
            Rsid rsid10 = new Rsid() { Val = "004B288E" };
            Rsid rsid11 = new Rsid() { Val = "004C4782" };
            Rsid rsid12 = new Rsid() { Val = "00553887" };
            Rsid rsid13 = new Rsid() { Val = "0056326A" };
            Rsid rsid14 = new Rsid() { Val = "005C7535" };
            Rsid rsid15 = new Rsid() { Val = "005D01CD" };
            Rsid rsid16 = new Rsid() { Val = "005F2B37" };
            Rsid rsid17 = new Rsid() { Val = "00644EAD" };
            Rsid rsid18 = new Rsid() { Val = "00650C0F" };
            Rsid rsid19 = new Rsid() { Val = "00670B2E" };
            Rsid rsid20 = new Rsid() { Val = "006E25E8" };
            Rsid rsid21 = new Rsid() { Val = "006F635D" };
            Rsid rsid22 = new Rsid() { Val = "0075587B" };
            Rsid rsid23 = new Rsid() { Val = "00763846" };
            Rsid rsid24 = new Rsid() { Val = "00773784" };
            Rsid rsid25 = new Rsid() { Val = "009E4A5B" };
            Rsid rsid26 = new Rsid() { Val = "009F30D9" };
            Rsid rsid27 = new Rsid() { Val = "00AA4DDD" };
            Rsid rsid28 = new Rsid() { Val = "00BD0111" };
            Rsid rsid29 = new Rsid() { Val = "00C63AD2" };
            Rsid rsid30 = new Rsid() { Val = "00C96451" };
            Rsid rsid31 = new Rsid() { Val = "00DB2712" };
            Rsid rsid32 = new Rsid() { Val = "00DE7E12" };
            Rsid rsid33 = new Rsid() { Val = "00E96696" };
            Rsid rsid34 = new Rsid() { Val = "00EE02E1" };
            Rsid rsid35 = new Rsid() { Val = "00F0258F" };
            Rsid rsid36 = new Rsid() { Val = "00F40B18" };
            Rsid rsid37 = new Rsid() { Val = "00F93A6C" };
            Rsid rsid38 = new Rsid() { Val = "00FE7005" };

            rsids1.Append(rsidRoot1);
            rsids1.Append(rsid1);
            rsids1.Append(rsid2);
            rsids1.Append(rsid3);
            rsids1.Append(rsid4);
            rsids1.Append(rsid5);
            rsids1.Append(rsid6);
            rsids1.Append(rsid7);
            rsids1.Append(rsid8);
            rsids1.Append(rsid9);
            rsids1.Append(rsid10);
            rsids1.Append(rsid11);
            rsids1.Append(rsid12);
            rsids1.Append(rsid13);
            rsids1.Append(rsid14);
            rsids1.Append(rsid15);
            rsids1.Append(rsid16);
            rsids1.Append(rsid17);
            rsids1.Append(rsid18);
            rsids1.Append(rsid19);
            rsids1.Append(rsid20);
            rsids1.Append(rsid21);
            rsids1.Append(rsid22);
            rsids1.Append(rsid23);
            rsids1.Append(rsid24);
            rsids1.Append(rsid25);
            rsids1.Append(rsid26);
            rsids1.Append(rsid27);
            rsids1.Append(rsid28);
            rsids1.Append(rsid29);
            rsids1.Append(rsid30);
            rsids1.Append(rsid31);
            rsids1.Append(rsid32);
            rsids1.Append(rsid33);
            rsids1.Append(rsid34);
            rsids1.Append(rsid35);
            rsids1.Append(rsid36);
            rsids1.Append(rsid37);
            rsids1.Append(rsid38);

            M.MathProperties mathProperties1 = new M.MathProperties();
            M.MathFont mathFont1 = new M.MathFont() { Val = "Cambria Math" };
            M.BreakBinary breakBinary1 = new M.BreakBinary() { Val = M.BreakBinaryOperatorValues.Before };
            M.BreakBinarySubtraction breakBinarySubtraction1 = new M.BreakBinarySubtraction() { Val = M.BreakBinarySubtractionValues.MinusMinus };
            M.SmallFraction smallFraction1 = new M.SmallFraction() { Val = M.BooleanValues.Zero };
            M.DisplayDefaults displayDefaults1 = new M.DisplayDefaults();
            M.LeftMargin leftMargin1 = new M.LeftMargin() { Val = (UInt32Value)0U };
            M.RightMargin rightMargin1 = new M.RightMargin() { Val = (UInt32Value)0U };
            M.DefaultJustification defaultJustification1 = new M.DefaultJustification() { Val = M.JustificationValues.CenterGroup };
            M.WrapIndent wrapIndent1 = new M.WrapIndent() { Val = (UInt32Value)1440U };
            M.IntegralLimitLocation integralLimitLocation1 = new M.IntegralLimitLocation() { Val = M.LimitLocationValues.SubscriptSuperscript };
            M.NaryLimitLocation naryLimitLocation1 = new M.NaryLimitLocation() { Val = M.LimitLocationValues.UnderOver };

            mathProperties1.Append(mathFont1);
            mathProperties1.Append(breakBinary1);
            mathProperties1.Append(breakBinarySubtraction1);
            mathProperties1.Append(smallFraction1);
            mathProperties1.Append(displayDefaults1);
            mathProperties1.Append(leftMargin1);
            mathProperties1.Append(rightMargin1);
            mathProperties1.Append(defaultJustification1);
            mathProperties1.Append(wrapIndent1);
            mathProperties1.Append(integralLimitLocation1);
            mathProperties1.Append(naryLimitLocation1);
            ThemeFontLanguages themeFontLanguages1 = new ThemeFontLanguages() { Val = "ru-RU" };
            ColorSchemeMapping colorSchemeMapping1 = new ColorSchemeMapping() { Background1 = ColorSchemeIndexValues.Light1, Text1 = ColorSchemeIndexValues.Dark1, Background2 = ColorSchemeIndexValues.Light2, Text2 = ColorSchemeIndexValues.Dark2, Accent1 = ColorSchemeIndexValues.Accent1, Accent2 = ColorSchemeIndexValues.Accent2, Accent3 = ColorSchemeIndexValues.Accent3, Accent4 = ColorSchemeIndexValues.Accent4, Accent5 = ColorSchemeIndexValues.Accent5, Accent6 = ColorSchemeIndexValues.Accent6, Hyperlink = ColorSchemeIndexValues.Hyperlink, FollowedHyperlink = ColorSchemeIndexValues.FollowedHyperlink };
            DoNotIncludeSubdocsInStats doNotIncludeSubdocsInStats1 = new DoNotIncludeSubdocsInStats();

            ShapeDefaults shapeDefaults1 = new ShapeDefaults();
            Ovml.ShapeDefaults shapeDefaults2 = new Ovml.ShapeDefaults() { Extension = V.ExtensionHandlingBehaviorValues.Edit, MaxShapeId = 1026 };

            Ovml.ShapeLayout shapeLayout1 = new Ovml.ShapeLayout() { Extension = V.ExtensionHandlingBehaviorValues.Edit };
            Ovml.ShapeIdMap shapeIdMap1 = new Ovml.ShapeIdMap() { Extension = V.ExtensionHandlingBehaviorValues.Edit, Data = "1" };

            shapeLayout1.Append(shapeIdMap1);

            shapeDefaults1.Append(shapeDefaults2);
            shapeDefaults1.Append(shapeLayout1);
            DecimalSymbol decimalSymbol1 = new DecimalSymbol() { Val = "," };
            ListSeparator listSeparator1 = new ListSeparator() { Val = ";" };
            OpenXmlUnknownElement openXmlUnknownElement1 = OpenXmlUnknownElement.CreateOpenXmlUnknownElement("<w15:chartTrackingRefBased xmlns:w15=\"http://schemas.microsoft.com/office/word/2012/wordml\" />");

            OpenXmlUnknownElement openXmlUnknownElement2 = OpenXmlUnknownElement.CreateOpenXmlUnknownElement("<w15:docId w15:val=\"{392499C7-C366-4064-B389-813FB0A8624A}\" xmlns:w15=\"http://schemas.microsoft.com/office/word/2012/wordml\" />");

            settings1.Append(zoom1);
            settings1.Append(proofState1);
            settings1.Append(stylePaneFormatFilter1);
            settings1.Append(doNotTrackMoves1);
            settings1.Append(defaultTabStop1);
            settings1.Append(noPunctuationKerning1);
            settings1.Append(characterSpacingControl1);
            settings1.Append(compatibility1);
            settings1.Append(rsids1);
            settings1.Append(mathProperties1);
            settings1.Append(themeFontLanguages1);
            settings1.Append(colorSchemeMapping1);
            settings1.Append(doNotIncludeSubdocsInStats1);
            settings1.Append(shapeDefaults1);
            settings1.Append(decimalSymbol1);
            settings1.Append(listSeparator1);
            settings1.Append(openXmlUnknownElement1);
            settings1.Append(openXmlUnknownElement2);

            documentSettingsPart1.Settings = settings1;
        }

        // Generates content of styleDefinitionsPart1.
        private void GenerateStyleDefinitionsPart1Content(StyleDefinitionsPart styleDefinitionsPart1)
        {
            Styles styles1 = new Styles() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 w15 w16se" } };
            styles1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            styles1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            styles1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            styles1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            styles1.AddNamespaceDeclaration("w15", "http://schemas.microsoft.com/office/word/2012/wordml");
            styles1.AddNamespaceDeclaration("w16se", "http://schemas.microsoft.com/office/word/2015/wordml/symex");

            DocDefaults docDefaults1 = new DocDefaults();

            RunPropertiesDefault runPropertiesDefault1 = new RunPropertiesDefault();

            RunPropertiesBaseStyle runPropertiesBaseStyle1 = new RunPropertiesBaseStyle();
            RunFonts runFonts1 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", EastAsia = "Times New Roman", ComplexScript = "Times New Roman" };
            Languages languages45 = new Languages() { Val = "ru-RU", EastAsia = "ru-RU", Bidi = "ar-SA" };

            runPropertiesBaseStyle1.Append(runFonts1);
            runPropertiesBaseStyle1.Append(languages45);

            runPropertiesDefault1.Append(runPropertiesBaseStyle1);
            ParagraphPropertiesDefault paragraphPropertiesDefault1 = new ParagraphPropertiesDefault();

            docDefaults1.Append(runPropertiesDefault1);
            docDefaults1.Append(paragraphPropertiesDefault1);

            LatentStyles latentStyles1 = new LatentStyles() { DefaultLockedState = false, DefaultUiPriority = 0, DefaultSemiHidden = false, DefaultUnhideWhenUsed = false, DefaultPrimaryStyle = false, Count = 371 };
            LatentStyleExceptionInfo latentStyleExceptionInfo1 = new LatentStyleExceptionInfo() { Name = "Normal", PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo2 = new LatentStyleExceptionInfo() { Name = "heading 1", PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo3 = new LatentStyleExceptionInfo() { Name = "heading 2", SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo4 = new LatentStyleExceptionInfo() { Name = "heading 3", SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo5 = new LatentStyleExceptionInfo() { Name = "heading 4", SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo6 = new LatentStyleExceptionInfo() { Name = "heading 5", SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo7 = new LatentStyleExceptionInfo() { Name = "heading 6", SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo8 = new LatentStyleExceptionInfo() { Name = "heading 7", SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo9 = new LatentStyleExceptionInfo() { Name = "heading 8", SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo10 = new LatentStyleExceptionInfo() { Name = "heading 9", SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo11 = new LatentStyleExceptionInfo() { Name = "caption", SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo12 = new LatentStyleExceptionInfo() { Name = "Title", PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo13 = new LatentStyleExceptionInfo() { Name = "Subtitle", PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo14 = new LatentStyleExceptionInfo() { Name = "Strong", PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo15 = new LatentStyleExceptionInfo() { Name = "Emphasis", PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo16 = new LatentStyleExceptionInfo() { Name = "Placeholder Text", UiPriority = 99, SemiHidden = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo17 = new LatentStyleExceptionInfo() { Name = "No Spacing", UiPriority = 1, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo18 = new LatentStyleExceptionInfo() { Name = "Light Shading", UiPriority = 60 };
            LatentStyleExceptionInfo latentStyleExceptionInfo19 = new LatentStyleExceptionInfo() { Name = "Light List", UiPriority = 61 };
            LatentStyleExceptionInfo latentStyleExceptionInfo20 = new LatentStyleExceptionInfo() { Name = "Light Grid", UiPriority = 62 };
            LatentStyleExceptionInfo latentStyleExceptionInfo21 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1", UiPriority = 63 };
            LatentStyleExceptionInfo latentStyleExceptionInfo22 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2", UiPriority = 64 };
            LatentStyleExceptionInfo latentStyleExceptionInfo23 = new LatentStyleExceptionInfo() { Name = "Medium List 1", UiPriority = 65 };
            LatentStyleExceptionInfo latentStyleExceptionInfo24 = new LatentStyleExceptionInfo() { Name = "Medium List 2", UiPriority = 66 };
            LatentStyleExceptionInfo latentStyleExceptionInfo25 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1", UiPriority = 67 };
            LatentStyleExceptionInfo latentStyleExceptionInfo26 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2", UiPriority = 68 };
            LatentStyleExceptionInfo latentStyleExceptionInfo27 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3", UiPriority = 69 };
            LatentStyleExceptionInfo latentStyleExceptionInfo28 = new LatentStyleExceptionInfo() { Name = "Dark List", UiPriority = 70 };
            LatentStyleExceptionInfo latentStyleExceptionInfo29 = new LatentStyleExceptionInfo() { Name = "Colorful Shading", UiPriority = 71 };
            LatentStyleExceptionInfo latentStyleExceptionInfo30 = new LatentStyleExceptionInfo() { Name = "Colorful List", UiPriority = 72 };
            LatentStyleExceptionInfo latentStyleExceptionInfo31 = new LatentStyleExceptionInfo() { Name = "Colorful Grid", UiPriority = 73 };
            LatentStyleExceptionInfo latentStyleExceptionInfo32 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 1", UiPriority = 60 };
            LatentStyleExceptionInfo latentStyleExceptionInfo33 = new LatentStyleExceptionInfo() { Name = "Light List Accent 1", UiPriority = 61 };
            LatentStyleExceptionInfo latentStyleExceptionInfo34 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 1", UiPriority = 62 };
            LatentStyleExceptionInfo latentStyleExceptionInfo35 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 1", UiPriority = 63 };
            LatentStyleExceptionInfo latentStyleExceptionInfo36 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 1", UiPriority = 64 };
            LatentStyleExceptionInfo latentStyleExceptionInfo37 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 1", UiPriority = 65 };
            LatentStyleExceptionInfo latentStyleExceptionInfo38 = new LatentStyleExceptionInfo() { Name = "Revision", UiPriority = 99, SemiHidden = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo39 = new LatentStyleExceptionInfo() { Name = "List Paragraph", UiPriority = 34, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo40 = new LatentStyleExceptionInfo() { Name = "Quote", UiPriority = 29, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo41 = new LatentStyleExceptionInfo() { Name = "Intense Quote", UiPriority = 30, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo42 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 1", UiPriority = 66 };
            LatentStyleExceptionInfo latentStyleExceptionInfo43 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 1", UiPriority = 67 };
            LatentStyleExceptionInfo latentStyleExceptionInfo44 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 1", UiPriority = 68 };
            LatentStyleExceptionInfo latentStyleExceptionInfo45 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 1", UiPriority = 69 };
            LatentStyleExceptionInfo latentStyleExceptionInfo46 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 1", UiPriority = 70 };
            LatentStyleExceptionInfo latentStyleExceptionInfo47 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 1", UiPriority = 71 };
            LatentStyleExceptionInfo latentStyleExceptionInfo48 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 1", UiPriority = 72 };
            LatentStyleExceptionInfo latentStyleExceptionInfo49 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 1", UiPriority = 73 };
            LatentStyleExceptionInfo latentStyleExceptionInfo50 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 2", UiPriority = 60 };
            LatentStyleExceptionInfo latentStyleExceptionInfo51 = new LatentStyleExceptionInfo() { Name = "Light List Accent 2", UiPriority = 61 };
            LatentStyleExceptionInfo latentStyleExceptionInfo52 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 2", UiPriority = 62 };
            LatentStyleExceptionInfo latentStyleExceptionInfo53 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 2", UiPriority = 63 };
            LatentStyleExceptionInfo latentStyleExceptionInfo54 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 2", UiPriority = 64 };
            LatentStyleExceptionInfo latentStyleExceptionInfo55 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 2", UiPriority = 65 };
            LatentStyleExceptionInfo latentStyleExceptionInfo56 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 2", UiPriority = 66 };
            LatentStyleExceptionInfo latentStyleExceptionInfo57 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 2", UiPriority = 67 };
            LatentStyleExceptionInfo latentStyleExceptionInfo58 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 2", UiPriority = 68 };
            LatentStyleExceptionInfo latentStyleExceptionInfo59 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 2", UiPriority = 69 };
            LatentStyleExceptionInfo latentStyleExceptionInfo60 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 2", UiPriority = 70 };
            LatentStyleExceptionInfo latentStyleExceptionInfo61 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 2", UiPriority = 71 };
            LatentStyleExceptionInfo latentStyleExceptionInfo62 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 2", UiPriority = 72 };
            LatentStyleExceptionInfo latentStyleExceptionInfo63 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 2", UiPriority = 73 };
            LatentStyleExceptionInfo latentStyleExceptionInfo64 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 3", UiPriority = 60 };
            LatentStyleExceptionInfo latentStyleExceptionInfo65 = new LatentStyleExceptionInfo() { Name = "Light List Accent 3", UiPriority = 61 };
            LatentStyleExceptionInfo latentStyleExceptionInfo66 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 3", UiPriority = 62 };
            LatentStyleExceptionInfo latentStyleExceptionInfo67 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 3", UiPriority = 63 };
            LatentStyleExceptionInfo latentStyleExceptionInfo68 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 3", UiPriority = 64 };
            LatentStyleExceptionInfo latentStyleExceptionInfo69 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 3", UiPriority = 65 };
            LatentStyleExceptionInfo latentStyleExceptionInfo70 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 3", UiPriority = 66 };
            LatentStyleExceptionInfo latentStyleExceptionInfo71 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 3", UiPriority = 67 };
            LatentStyleExceptionInfo latentStyleExceptionInfo72 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 3", UiPriority = 68 };
            LatentStyleExceptionInfo latentStyleExceptionInfo73 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 3", UiPriority = 69 };
            LatentStyleExceptionInfo latentStyleExceptionInfo74 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 3", UiPriority = 70 };
            LatentStyleExceptionInfo latentStyleExceptionInfo75 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 3", UiPriority = 71 };
            LatentStyleExceptionInfo latentStyleExceptionInfo76 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 3", UiPriority = 72 };
            LatentStyleExceptionInfo latentStyleExceptionInfo77 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 3", UiPriority = 73 };
            LatentStyleExceptionInfo latentStyleExceptionInfo78 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 4", UiPriority = 60 };
            LatentStyleExceptionInfo latentStyleExceptionInfo79 = new LatentStyleExceptionInfo() { Name = "Light List Accent 4", UiPriority = 61 };
            LatentStyleExceptionInfo latentStyleExceptionInfo80 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 4", UiPriority = 62 };
            LatentStyleExceptionInfo latentStyleExceptionInfo81 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 4", UiPriority = 63 };
            LatentStyleExceptionInfo latentStyleExceptionInfo82 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 4", UiPriority = 64 };
            LatentStyleExceptionInfo latentStyleExceptionInfo83 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 4", UiPriority = 65 };
            LatentStyleExceptionInfo latentStyleExceptionInfo84 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 4", UiPriority = 66 };
            LatentStyleExceptionInfo latentStyleExceptionInfo85 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 4", UiPriority = 67 };
            LatentStyleExceptionInfo latentStyleExceptionInfo86 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 4", UiPriority = 68 };
            LatentStyleExceptionInfo latentStyleExceptionInfo87 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 4", UiPriority = 69 };
            LatentStyleExceptionInfo latentStyleExceptionInfo88 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 4", UiPriority = 70 };
            LatentStyleExceptionInfo latentStyleExceptionInfo89 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 4", UiPriority = 71 };
            LatentStyleExceptionInfo latentStyleExceptionInfo90 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 4", UiPriority = 72 };
            LatentStyleExceptionInfo latentStyleExceptionInfo91 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 4", UiPriority = 73 };
            LatentStyleExceptionInfo latentStyleExceptionInfo92 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 5", UiPriority = 60 };
            LatentStyleExceptionInfo latentStyleExceptionInfo93 = new LatentStyleExceptionInfo() { Name = "Light List Accent 5", UiPriority = 61 };
            LatentStyleExceptionInfo latentStyleExceptionInfo94 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 5", UiPriority = 62 };
            LatentStyleExceptionInfo latentStyleExceptionInfo95 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 5", UiPriority = 63 };
            LatentStyleExceptionInfo latentStyleExceptionInfo96 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 5", UiPriority = 64 };
            LatentStyleExceptionInfo latentStyleExceptionInfo97 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 5", UiPriority = 65 };
            LatentStyleExceptionInfo latentStyleExceptionInfo98 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 5", UiPriority = 66 };
            LatentStyleExceptionInfo latentStyleExceptionInfo99 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 5", UiPriority = 67 };
            LatentStyleExceptionInfo latentStyleExceptionInfo100 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 5", UiPriority = 68 };
            LatentStyleExceptionInfo latentStyleExceptionInfo101 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 5", UiPriority = 69 };
            LatentStyleExceptionInfo latentStyleExceptionInfo102 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 5", UiPriority = 70 };
            LatentStyleExceptionInfo latentStyleExceptionInfo103 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 5", UiPriority = 71 };
            LatentStyleExceptionInfo latentStyleExceptionInfo104 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 5", UiPriority = 72 };
            LatentStyleExceptionInfo latentStyleExceptionInfo105 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 5", UiPriority = 73 };
            LatentStyleExceptionInfo latentStyleExceptionInfo106 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 6", UiPriority = 60 };
            LatentStyleExceptionInfo latentStyleExceptionInfo107 = new LatentStyleExceptionInfo() { Name = "Light List Accent 6", UiPriority = 61 };
            LatentStyleExceptionInfo latentStyleExceptionInfo108 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 6", UiPriority = 62 };
            LatentStyleExceptionInfo latentStyleExceptionInfo109 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 6", UiPriority = 63 };
            LatentStyleExceptionInfo latentStyleExceptionInfo110 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 6", UiPriority = 64 };
            LatentStyleExceptionInfo latentStyleExceptionInfo111 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 6", UiPriority = 65 };
            LatentStyleExceptionInfo latentStyleExceptionInfo112 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 6", UiPriority = 66 };
            LatentStyleExceptionInfo latentStyleExceptionInfo113 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 6", UiPriority = 67 };
            LatentStyleExceptionInfo latentStyleExceptionInfo114 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 6", UiPriority = 68 };
            LatentStyleExceptionInfo latentStyleExceptionInfo115 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 6", UiPriority = 69 };
            LatentStyleExceptionInfo latentStyleExceptionInfo116 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 6", UiPriority = 70 };
            LatentStyleExceptionInfo latentStyleExceptionInfo117 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 6", UiPriority = 71 };
            LatentStyleExceptionInfo latentStyleExceptionInfo118 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 6", UiPriority = 72 };
            LatentStyleExceptionInfo latentStyleExceptionInfo119 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 6", UiPriority = 73 };
            LatentStyleExceptionInfo latentStyleExceptionInfo120 = new LatentStyleExceptionInfo() { Name = "Subtle Emphasis", UiPriority = 19, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo121 = new LatentStyleExceptionInfo() { Name = "Intense Emphasis", UiPriority = 21, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo122 = new LatentStyleExceptionInfo() { Name = "Subtle Reference", UiPriority = 31, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo123 = new LatentStyleExceptionInfo() { Name = "Intense Reference", UiPriority = 32, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo124 = new LatentStyleExceptionInfo() { Name = "Book Title", UiPriority = 33, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo125 = new LatentStyleExceptionInfo() { Name = "Bibliography", UiPriority = 37, SemiHidden = true, UnhideWhenUsed = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo126 = new LatentStyleExceptionInfo() { Name = "TOC Heading", UiPriority = 39, SemiHidden = true, UnhideWhenUsed = true, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo127 = new LatentStyleExceptionInfo() { Name = "Plain Table 1", UiPriority = 41 };
            LatentStyleExceptionInfo latentStyleExceptionInfo128 = new LatentStyleExceptionInfo() { Name = "Plain Table 2", UiPriority = 42 };
            LatentStyleExceptionInfo latentStyleExceptionInfo129 = new LatentStyleExceptionInfo() { Name = "Plain Table 3", UiPriority = 43 };
            LatentStyleExceptionInfo latentStyleExceptionInfo130 = new LatentStyleExceptionInfo() { Name = "Plain Table 4", UiPriority = 44 };
            LatentStyleExceptionInfo latentStyleExceptionInfo131 = new LatentStyleExceptionInfo() { Name = "Plain Table 5", UiPriority = 45 };
            LatentStyleExceptionInfo latentStyleExceptionInfo132 = new LatentStyleExceptionInfo() { Name = "Grid Table Light", UiPriority = 40 };
            LatentStyleExceptionInfo latentStyleExceptionInfo133 = new LatentStyleExceptionInfo() { Name = "Grid Table 1 Light", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo134 = new LatentStyleExceptionInfo() { Name = "Grid Table 2", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo135 = new LatentStyleExceptionInfo() { Name = "Grid Table 3", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo136 = new LatentStyleExceptionInfo() { Name = "Grid Table 4", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo137 = new LatentStyleExceptionInfo() { Name = "Grid Table 5 Dark", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo138 = new LatentStyleExceptionInfo() { Name = "Grid Table 6 Colorful", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo139 = new LatentStyleExceptionInfo() { Name = "Grid Table 7 Colorful", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo140 = new LatentStyleExceptionInfo() { Name = "Grid Table 1 Light Accent 1", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo141 = new LatentStyleExceptionInfo() { Name = "Grid Table 2 Accent 1", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo142 = new LatentStyleExceptionInfo() { Name = "Grid Table 3 Accent 1", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo143 = new LatentStyleExceptionInfo() { Name = "Grid Table 4 Accent 1", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo144 = new LatentStyleExceptionInfo() { Name = "Grid Table 5 Dark Accent 1", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo145 = new LatentStyleExceptionInfo() { Name = "Grid Table 6 Colorful Accent 1", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo146 = new LatentStyleExceptionInfo() { Name = "Grid Table 7 Colorful Accent 1", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo147 = new LatentStyleExceptionInfo() { Name = "Grid Table 1 Light Accent 2", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo148 = new LatentStyleExceptionInfo() { Name = "Grid Table 2 Accent 2", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo149 = new LatentStyleExceptionInfo() { Name = "Grid Table 3 Accent 2", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo150 = new LatentStyleExceptionInfo() { Name = "Grid Table 4 Accent 2", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo151 = new LatentStyleExceptionInfo() { Name = "Grid Table 5 Dark Accent 2", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo152 = new LatentStyleExceptionInfo() { Name = "Grid Table 6 Colorful Accent 2", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo153 = new LatentStyleExceptionInfo() { Name = "Grid Table 7 Colorful Accent 2", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo154 = new LatentStyleExceptionInfo() { Name = "Grid Table 1 Light Accent 3", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo155 = new LatentStyleExceptionInfo() { Name = "Grid Table 2 Accent 3", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo156 = new LatentStyleExceptionInfo() { Name = "Grid Table 3 Accent 3", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo157 = new LatentStyleExceptionInfo() { Name = "Grid Table 4 Accent 3", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo158 = new LatentStyleExceptionInfo() { Name = "Grid Table 5 Dark Accent 3", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo159 = new LatentStyleExceptionInfo() { Name = "Grid Table 6 Colorful Accent 3", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo160 = new LatentStyleExceptionInfo() { Name = "Grid Table 7 Colorful Accent 3", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo161 = new LatentStyleExceptionInfo() { Name = "Grid Table 1 Light Accent 4", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo162 = new LatentStyleExceptionInfo() { Name = "Grid Table 2 Accent 4", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo163 = new LatentStyleExceptionInfo() { Name = "Grid Table 3 Accent 4", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo164 = new LatentStyleExceptionInfo() { Name = "Grid Table 4 Accent 4", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo165 = new LatentStyleExceptionInfo() { Name = "Grid Table 5 Dark Accent 4", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo166 = new LatentStyleExceptionInfo() { Name = "Grid Table 6 Colorful Accent 4", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo167 = new LatentStyleExceptionInfo() { Name = "Grid Table 7 Colorful Accent 4", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo168 = new LatentStyleExceptionInfo() { Name = "Grid Table 1 Light Accent 5", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo169 = new LatentStyleExceptionInfo() { Name = "Grid Table 2 Accent 5", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo170 = new LatentStyleExceptionInfo() { Name = "Grid Table 3 Accent 5", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo171 = new LatentStyleExceptionInfo() { Name = "Grid Table 4 Accent 5", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo172 = new LatentStyleExceptionInfo() { Name = "Grid Table 5 Dark Accent 5", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo173 = new LatentStyleExceptionInfo() { Name = "Grid Table 6 Colorful Accent 5", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo174 = new LatentStyleExceptionInfo() { Name = "Grid Table 7 Colorful Accent 5", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo175 = new LatentStyleExceptionInfo() { Name = "Grid Table 1 Light Accent 6", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo176 = new LatentStyleExceptionInfo() { Name = "Grid Table 2 Accent 6", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo177 = new LatentStyleExceptionInfo() { Name = "Grid Table 3 Accent 6", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo178 = new LatentStyleExceptionInfo() { Name = "Grid Table 4 Accent 6", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo179 = new LatentStyleExceptionInfo() { Name = "Grid Table 5 Dark Accent 6", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo180 = new LatentStyleExceptionInfo() { Name = "Grid Table 6 Colorful Accent 6", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo181 = new LatentStyleExceptionInfo() { Name = "Grid Table 7 Colorful Accent 6", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo182 = new LatentStyleExceptionInfo() { Name = "List Table 1 Light", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo183 = new LatentStyleExceptionInfo() { Name = "List Table 2", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo184 = new LatentStyleExceptionInfo() { Name = "List Table 3", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo185 = new LatentStyleExceptionInfo() { Name = "List Table 4", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo186 = new LatentStyleExceptionInfo() { Name = "List Table 5 Dark", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo187 = new LatentStyleExceptionInfo() { Name = "List Table 6 Colorful", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo188 = new LatentStyleExceptionInfo() { Name = "List Table 7 Colorful", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo189 = new LatentStyleExceptionInfo() { Name = "List Table 1 Light Accent 1", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo190 = new LatentStyleExceptionInfo() { Name = "List Table 2 Accent 1", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo191 = new LatentStyleExceptionInfo() { Name = "List Table 3 Accent 1", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo192 = new LatentStyleExceptionInfo() { Name = "List Table 4 Accent 1", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo193 = new LatentStyleExceptionInfo() { Name = "List Table 5 Dark Accent 1", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo194 = new LatentStyleExceptionInfo() { Name = "List Table 6 Colorful Accent 1", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo195 = new LatentStyleExceptionInfo() { Name = "List Table 7 Colorful Accent 1", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo196 = new LatentStyleExceptionInfo() { Name = "List Table 1 Light Accent 2", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo197 = new LatentStyleExceptionInfo() { Name = "List Table 2 Accent 2", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo198 = new LatentStyleExceptionInfo() { Name = "List Table 3 Accent 2", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo199 = new LatentStyleExceptionInfo() { Name = "List Table 4 Accent 2", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo200 = new LatentStyleExceptionInfo() { Name = "List Table 5 Dark Accent 2", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo201 = new LatentStyleExceptionInfo() { Name = "List Table 6 Colorful Accent 2", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo202 = new LatentStyleExceptionInfo() { Name = "List Table 7 Colorful Accent 2", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo203 = new LatentStyleExceptionInfo() { Name = "List Table 1 Light Accent 3", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo204 = new LatentStyleExceptionInfo() { Name = "List Table 2 Accent 3", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo205 = new LatentStyleExceptionInfo() { Name = "List Table 3 Accent 3", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo206 = new LatentStyleExceptionInfo() { Name = "List Table 4 Accent 3", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo207 = new LatentStyleExceptionInfo() { Name = "List Table 5 Dark Accent 3", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo208 = new LatentStyleExceptionInfo() { Name = "List Table 6 Colorful Accent 3", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo209 = new LatentStyleExceptionInfo() { Name = "List Table 7 Colorful Accent 3", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo210 = new LatentStyleExceptionInfo() { Name = "List Table 1 Light Accent 4", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo211 = new LatentStyleExceptionInfo() { Name = "List Table 2 Accent 4", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo212 = new LatentStyleExceptionInfo() { Name = "List Table 3 Accent 4", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo213 = new LatentStyleExceptionInfo() { Name = "List Table 4 Accent 4", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo214 = new LatentStyleExceptionInfo() { Name = "List Table 5 Dark Accent 4", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo215 = new LatentStyleExceptionInfo() { Name = "List Table 6 Colorful Accent 4", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo216 = new LatentStyleExceptionInfo() { Name = "List Table 7 Colorful Accent 4", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo217 = new LatentStyleExceptionInfo() { Name = "List Table 1 Light Accent 5", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo218 = new LatentStyleExceptionInfo() { Name = "List Table 2 Accent 5", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo219 = new LatentStyleExceptionInfo() { Name = "List Table 3 Accent 5", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo220 = new LatentStyleExceptionInfo() { Name = "List Table 4 Accent 5", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo221 = new LatentStyleExceptionInfo() { Name = "List Table 5 Dark Accent 5", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo222 = new LatentStyleExceptionInfo() { Name = "List Table 6 Colorful Accent 5", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo223 = new LatentStyleExceptionInfo() { Name = "List Table 7 Colorful Accent 5", UiPriority = 52 };
            LatentStyleExceptionInfo latentStyleExceptionInfo224 = new LatentStyleExceptionInfo() { Name = "List Table 1 Light Accent 6", UiPriority = 46 };
            LatentStyleExceptionInfo latentStyleExceptionInfo225 = new LatentStyleExceptionInfo() { Name = "List Table 2 Accent 6", UiPriority = 47 };
            LatentStyleExceptionInfo latentStyleExceptionInfo226 = new LatentStyleExceptionInfo() { Name = "List Table 3 Accent 6", UiPriority = 48 };
            LatentStyleExceptionInfo latentStyleExceptionInfo227 = new LatentStyleExceptionInfo() { Name = "List Table 4 Accent 6", UiPriority = 49 };
            LatentStyleExceptionInfo latentStyleExceptionInfo228 = new LatentStyleExceptionInfo() { Name = "List Table 5 Dark Accent 6", UiPriority = 50 };
            LatentStyleExceptionInfo latentStyleExceptionInfo229 = new LatentStyleExceptionInfo() { Name = "List Table 6 Colorful Accent 6", UiPriority = 51 };
            LatentStyleExceptionInfo latentStyleExceptionInfo230 = new LatentStyleExceptionInfo() { Name = "List Table 7 Colorful Accent 6", UiPriority = 52 };

            latentStyles1.Append(latentStyleExceptionInfo1);
            latentStyles1.Append(latentStyleExceptionInfo2);
            latentStyles1.Append(latentStyleExceptionInfo3);
            latentStyles1.Append(latentStyleExceptionInfo4);
            latentStyles1.Append(latentStyleExceptionInfo5);
            latentStyles1.Append(latentStyleExceptionInfo6);
            latentStyles1.Append(latentStyleExceptionInfo7);
            latentStyles1.Append(latentStyleExceptionInfo8);
            latentStyles1.Append(latentStyleExceptionInfo9);
            latentStyles1.Append(latentStyleExceptionInfo10);
            latentStyles1.Append(latentStyleExceptionInfo11);
            latentStyles1.Append(latentStyleExceptionInfo12);
            latentStyles1.Append(latentStyleExceptionInfo13);
            latentStyles1.Append(latentStyleExceptionInfo14);
            latentStyles1.Append(latentStyleExceptionInfo15);
            latentStyles1.Append(latentStyleExceptionInfo16);
            latentStyles1.Append(latentStyleExceptionInfo17);
            latentStyles1.Append(latentStyleExceptionInfo18);
            latentStyles1.Append(latentStyleExceptionInfo19);
            latentStyles1.Append(latentStyleExceptionInfo20);
            latentStyles1.Append(latentStyleExceptionInfo21);
            latentStyles1.Append(latentStyleExceptionInfo22);
            latentStyles1.Append(latentStyleExceptionInfo23);
            latentStyles1.Append(latentStyleExceptionInfo24);
            latentStyles1.Append(latentStyleExceptionInfo25);
            latentStyles1.Append(latentStyleExceptionInfo26);
            latentStyles1.Append(latentStyleExceptionInfo27);
            latentStyles1.Append(latentStyleExceptionInfo28);
            latentStyles1.Append(latentStyleExceptionInfo29);
            latentStyles1.Append(latentStyleExceptionInfo30);
            latentStyles1.Append(latentStyleExceptionInfo31);
            latentStyles1.Append(latentStyleExceptionInfo32);
            latentStyles1.Append(latentStyleExceptionInfo33);
            latentStyles1.Append(latentStyleExceptionInfo34);
            latentStyles1.Append(latentStyleExceptionInfo35);
            latentStyles1.Append(latentStyleExceptionInfo36);
            latentStyles1.Append(latentStyleExceptionInfo37);
            latentStyles1.Append(latentStyleExceptionInfo38);
            latentStyles1.Append(latentStyleExceptionInfo39);
            latentStyles1.Append(latentStyleExceptionInfo40);
            latentStyles1.Append(latentStyleExceptionInfo41);
            latentStyles1.Append(latentStyleExceptionInfo42);
            latentStyles1.Append(latentStyleExceptionInfo43);
            latentStyles1.Append(latentStyleExceptionInfo44);
            latentStyles1.Append(latentStyleExceptionInfo45);
            latentStyles1.Append(latentStyleExceptionInfo46);
            latentStyles1.Append(latentStyleExceptionInfo47);
            latentStyles1.Append(latentStyleExceptionInfo48);
            latentStyles1.Append(latentStyleExceptionInfo49);
            latentStyles1.Append(latentStyleExceptionInfo50);
            latentStyles1.Append(latentStyleExceptionInfo51);
            latentStyles1.Append(latentStyleExceptionInfo52);
            latentStyles1.Append(latentStyleExceptionInfo53);
            latentStyles1.Append(latentStyleExceptionInfo54);
            latentStyles1.Append(latentStyleExceptionInfo55);
            latentStyles1.Append(latentStyleExceptionInfo56);
            latentStyles1.Append(latentStyleExceptionInfo57);
            latentStyles1.Append(latentStyleExceptionInfo58);
            latentStyles1.Append(latentStyleExceptionInfo59);
            latentStyles1.Append(latentStyleExceptionInfo60);
            latentStyles1.Append(latentStyleExceptionInfo61);
            latentStyles1.Append(latentStyleExceptionInfo62);
            latentStyles1.Append(latentStyleExceptionInfo63);
            latentStyles1.Append(latentStyleExceptionInfo64);
            latentStyles1.Append(latentStyleExceptionInfo65);
            latentStyles1.Append(latentStyleExceptionInfo66);
            latentStyles1.Append(latentStyleExceptionInfo67);
            latentStyles1.Append(latentStyleExceptionInfo68);
            latentStyles1.Append(latentStyleExceptionInfo69);
            latentStyles1.Append(latentStyleExceptionInfo70);
            latentStyles1.Append(latentStyleExceptionInfo71);
            latentStyles1.Append(latentStyleExceptionInfo72);
            latentStyles1.Append(latentStyleExceptionInfo73);
            latentStyles1.Append(latentStyleExceptionInfo74);
            latentStyles1.Append(latentStyleExceptionInfo75);
            latentStyles1.Append(latentStyleExceptionInfo76);
            latentStyles1.Append(latentStyleExceptionInfo77);
            latentStyles1.Append(latentStyleExceptionInfo78);
            latentStyles1.Append(latentStyleExceptionInfo79);
            latentStyles1.Append(latentStyleExceptionInfo80);
            latentStyles1.Append(latentStyleExceptionInfo81);
            latentStyles1.Append(latentStyleExceptionInfo82);
            latentStyles1.Append(latentStyleExceptionInfo83);
            latentStyles1.Append(latentStyleExceptionInfo84);
            latentStyles1.Append(latentStyleExceptionInfo85);
            latentStyles1.Append(latentStyleExceptionInfo86);
            latentStyles1.Append(latentStyleExceptionInfo87);
            latentStyles1.Append(latentStyleExceptionInfo88);
            latentStyles1.Append(latentStyleExceptionInfo89);
            latentStyles1.Append(latentStyleExceptionInfo90);
            latentStyles1.Append(latentStyleExceptionInfo91);
            latentStyles1.Append(latentStyleExceptionInfo92);
            latentStyles1.Append(latentStyleExceptionInfo93);
            latentStyles1.Append(latentStyleExceptionInfo94);
            latentStyles1.Append(latentStyleExceptionInfo95);
            latentStyles1.Append(latentStyleExceptionInfo96);
            latentStyles1.Append(latentStyleExceptionInfo97);
            latentStyles1.Append(latentStyleExceptionInfo98);
            latentStyles1.Append(latentStyleExceptionInfo99);
            latentStyles1.Append(latentStyleExceptionInfo100);
            latentStyles1.Append(latentStyleExceptionInfo101);
            latentStyles1.Append(latentStyleExceptionInfo102);
            latentStyles1.Append(latentStyleExceptionInfo103);
            latentStyles1.Append(latentStyleExceptionInfo104);
            latentStyles1.Append(latentStyleExceptionInfo105);
            latentStyles1.Append(latentStyleExceptionInfo106);
            latentStyles1.Append(latentStyleExceptionInfo107);
            latentStyles1.Append(latentStyleExceptionInfo108);
            latentStyles1.Append(latentStyleExceptionInfo109);
            latentStyles1.Append(latentStyleExceptionInfo110);
            latentStyles1.Append(latentStyleExceptionInfo111);
            latentStyles1.Append(latentStyleExceptionInfo112);
            latentStyles1.Append(latentStyleExceptionInfo113);
            latentStyles1.Append(latentStyleExceptionInfo114);
            latentStyles1.Append(latentStyleExceptionInfo115);
            latentStyles1.Append(latentStyleExceptionInfo116);
            latentStyles1.Append(latentStyleExceptionInfo117);
            latentStyles1.Append(latentStyleExceptionInfo118);
            latentStyles1.Append(latentStyleExceptionInfo119);
            latentStyles1.Append(latentStyleExceptionInfo120);
            latentStyles1.Append(latentStyleExceptionInfo121);
            latentStyles1.Append(latentStyleExceptionInfo122);
            latentStyles1.Append(latentStyleExceptionInfo123);
            latentStyles1.Append(latentStyleExceptionInfo124);
            latentStyles1.Append(latentStyleExceptionInfo125);
            latentStyles1.Append(latentStyleExceptionInfo126);
            latentStyles1.Append(latentStyleExceptionInfo127);
            latentStyles1.Append(latentStyleExceptionInfo128);
            latentStyles1.Append(latentStyleExceptionInfo129);
            latentStyles1.Append(latentStyleExceptionInfo130);
            latentStyles1.Append(latentStyleExceptionInfo131);
            latentStyles1.Append(latentStyleExceptionInfo132);
            latentStyles1.Append(latentStyleExceptionInfo133);
            latentStyles1.Append(latentStyleExceptionInfo134);
            latentStyles1.Append(latentStyleExceptionInfo135);
            latentStyles1.Append(latentStyleExceptionInfo136);
            latentStyles1.Append(latentStyleExceptionInfo137);
            latentStyles1.Append(latentStyleExceptionInfo138);
            latentStyles1.Append(latentStyleExceptionInfo139);
            latentStyles1.Append(latentStyleExceptionInfo140);
            latentStyles1.Append(latentStyleExceptionInfo141);
            latentStyles1.Append(latentStyleExceptionInfo142);
            latentStyles1.Append(latentStyleExceptionInfo143);
            latentStyles1.Append(latentStyleExceptionInfo144);
            latentStyles1.Append(latentStyleExceptionInfo145);
            latentStyles1.Append(latentStyleExceptionInfo146);
            latentStyles1.Append(latentStyleExceptionInfo147);
            latentStyles1.Append(latentStyleExceptionInfo148);
            latentStyles1.Append(latentStyleExceptionInfo149);
            latentStyles1.Append(latentStyleExceptionInfo150);
            latentStyles1.Append(latentStyleExceptionInfo151);
            latentStyles1.Append(latentStyleExceptionInfo152);
            latentStyles1.Append(latentStyleExceptionInfo153);
            latentStyles1.Append(latentStyleExceptionInfo154);
            latentStyles1.Append(latentStyleExceptionInfo155);
            latentStyles1.Append(latentStyleExceptionInfo156);
            latentStyles1.Append(latentStyleExceptionInfo157);
            latentStyles1.Append(latentStyleExceptionInfo158);
            latentStyles1.Append(latentStyleExceptionInfo159);
            latentStyles1.Append(latentStyleExceptionInfo160);
            latentStyles1.Append(latentStyleExceptionInfo161);
            latentStyles1.Append(latentStyleExceptionInfo162);
            latentStyles1.Append(latentStyleExceptionInfo163);
            latentStyles1.Append(latentStyleExceptionInfo164);
            latentStyles1.Append(latentStyleExceptionInfo165);
            latentStyles1.Append(latentStyleExceptionInfo166);
            latentStyles1.Append(latentStyleExceptionInfo167);
            latentStyles1.Append(latentStyleExceptionInfo168);
            latentStyles1.Append(latentStyleExceptionInfo169);
            latentStyles1.Append(latentStyleExceptionInfo170);
            latentStyles1.Append(latentStyleExceptionInfo171);
            latentStyles1.Append(latentStyleExceptionInfo172);
            latentStyles1.Append(latentStyleExceptionInfo173);
            latentStyles1.Append(latentStyleExceptionInfo174);
            latentStyles1.Append(latentStyleExceptionInfo175);
            latentStyles1.Append(latentStyleExceptionInfo176);
            latentStyles1.Append(latentStyleExceptionInfo177);
            latentStyles1.Append(latentStyleExceptionInfo178);
            latentStyles1.Append(latentStyleExceptionInfo179);
            latentStyles1.Append(latentStyleExceptionInfo180);
            latentStyles1.Append(latentStyleExceptionInfo181);
            latentStyles1.Append(latentStyleExceptionInfo182);
            latentStyles1.Append(latentStyleExceptionInfo183);
            latentStyles1.Append(latentStyleExceptionInfo184);
            latentStyles1.Append(latentStyleExceptionInfo185);
            latentStyles1.Append(latentStyleExceptionInfo186);
            latentStyles1.Append(latentStyleExceptionInfo187);
            latentStyles1.Append(latentStyleExceptionInfo188);
            latentStyles1.Append(latentStyleExceptionInfo189);
            latentStyles1.Append(latentStyleExceptionInfo190);
            latentStyles1.Append(latentStyleExceptionInfo191);
            latentStyles1.Append(latentStyleExceptionInfo192);
            latentStyles1.Append(latentStyleExceptionInfo193);
            latentStyles1.Append(latentStyleExceptionInfo194);
            latentStyles1.Append(latentStyleExceptionInfo195);
            latentStyles1.Append(latentStyleExceptionInfo196);
            latentStyles1.Append(latentStyleExceptionInfo197);
            latentStyles1.Append(latentStyleExceptionInfo198);
            latentStyles1.Append(latentStyleExceptionInfo199);
            latentStyles1.Append(latentStyleExceptionInfo200);
            latentStyles1.Append(latentStyleExceptionInfo201);
            latentStyles1.Append(latentStyleExceptionInfo202);
            latentStyles1.Append(latentStyleExceptionInfo203);
            latentStyles1.Append(latentStyleExceptionInfo204);
            latentStyles1.Append(latentStyleExceptionInfo205);
            latentStyles1.Append(latentStyleExceptionInfo206);
            latentStyles1.Append(latentStyleExceptionInfo207);
            latentStyles1.Append(latentStyleExceptionInfo208);
            latentStyles1.Append(latentStyleExceptionInfo209);
            latentStyles1.Append(latentStyleExceptionInfo210);
            latentStyles1.Append(latentStyleExceptionInfo211);
            latentStyles1.Append(latentStyleExceptionInfo212);
            latentStyles1.Append(latentStyleExceptionInfo213);
            latentStyles1.Append(latentStyleExceptionInfo214);
            latentStyles1.Append(latentStyleExceptionInfo215);
            latentStyles1.Append(latentStyleExceptionInfo216);
            latentStyles1.Append(latentStyleExceptionInfo217);
            latentStyles1.Append(latentStyleExceptionInfo218);
            latentStyles1.Append(latentStyleExceptionInfo219);
            latentStyles1.Append(latentStyleExceptionInfo220);
            latentStyles1.Append(latentStyleExceptionInfo221);
            latentStyles1.Append(latentStyleExceptionInfo222);
            latentStyles1.Append(latentStyleExceptionInfo223);
            latentStyles1.Append(latentStyleExceptionInfo224);
            latentStyles1.Append(latentStyleExceptionInfo225);
            latentStyles1.Append(latentStyleExceptionInfo226);
            latentStyles1.Append(latentStyleExceptionInfo227);
            latentStyles1.Append(latentStyleExceptionInfo228);
            latentStyles1.Append(latentStyleExceptionInfo229);
            latentStyles1.Append(latentStyleExceptionInfo230);

            Style style1 = new Style() { Type = StyleValues.Paragraph, StyleId = "a", Default = true };
            StyleName styleName1 = new StyleName() { Val = "Normal" };
            PrimaryStyle primaryStyle1 = new PrimaryStyle();

            StyleRunProperties styleRunProperties1 = new StyleRunProperties();
            FontSize fontSize69 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript69 = new FontSizeComplexScript() { Val = "24" };

            styleRunProperties1.Append(fontSize69);
            styleRunProperties1.Append(fontSizeComplexScript69);

            style1.Append(styleName1);
            style1.Append(primaryStyle1);
            style1.Append(styleRunProperties1);

            Style style2 = new Style() { Type = StyleValues.Character, StyleId = "a0", Default = true };
            StyleName styleName2 = new StyleName() { Val = "Default Paragraph Font" };
            SemiHidden semiHidden1 = new SemiHidden();

            style2.Append(styleName2);
            style2.Append(semiHidden1);

            Style style3 = new Style() { Type = StyleValues.Table, StyleId = "a1", Default = true };
            StyleName styleName3 = new StyleName() { Val = "Normal Table" };
            SemiHidden semiHidden2 = new SemiHidden();

            StyleTableProperties styleTableProperties1 = new StyleTableProperties();
            TableIndentation tableIndentation4 = new TableIndentation() { Width = 0, Type = TableWidthUnitValues.Dxa };

            TableCellMarginDefault tableCellMarginDefault1 = new TableCellMarginDefault();
            TopMargin topMargin1 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            TableCellLeftMargin tableCellLeftMargin1 = new TableCellLeftMargin() { Width = 108, Type = TableWidthValues.Dxa };
            BottomMargin bottomMargin1 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            TableCellRightMargin tableCellRightMargin1 = new TableCellRightMargin() { Width = 108, Type = TableWidthValues.Dxa };

            tableCellMarginDefault1.Append(topMargin1);
            tableCellMarginDefault1.Append(tableCellLeftMargin1);
            tableCellMarginDefault1.Append(bottomMargin1);
            tableCellMarginDefault1.Append(tableCellRightMargin1);

            styleTableProperties1.Append(tableIndentation4);
            styleTableProperties1.Append(tableCellMarginDefault1);

            style3.Append(styleName3);
            style3.Append(semiHidden2);
            style3.Append(styleTableProperties1);

            Style style4 = new Style() { Type = StyleValues.Numbering, StyleId = "a2", Default = true };
            StyleName styleName4 = new StyleName() { Val = "No List" };
            SemiHidden semiHidden3 = new SemiHidden();

            style4.Append(styleName4);
            style4.Append(semiHidden3);

            Style style5 = new Style() { Type = StyleValues.Table, StyleId = "a3" };
            StyleName styleName5 = new StyleName() { Val = "Table Grid" };
            BasedOn basedOn1 = new BasedOn() { Val = "a1" };
            Rsid rsid39 = new Rsid() { Val = "005F2B37" };

            StyleTableProperties styleTableProperties2 = new StyleTableProperties();

            TableBorders tableBorders8 = new TableBorders();
            TopBorder topBorder233 = new TopBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            LeftBorder leftBorder224 = new LeftBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder239 = new BottomBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            RightBorder rightBorder224 = new RightBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            InsideHorizontalBorder insideHorizontalBorder7 = new InsideHorizontalBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };
            InsideVerticalBorder insideVerticalBorder7 = new InsideVerticalBorder() { Val = BorderValues.Single, Color = "auto", Size = (UInt32Value)4U, Space = (UInt32Value)0U };

            tableBorders8.Append(topBorder233);
            tableBorders8.Append(leftBorder224);
            tableBorders8.Append(bottomBorder239);
            tableBorders8.Append(rightBorder224);
            tableBorders8.Append(insideHorizontalBorder7);
            tableBorders8.Append(insideVerticalBorder7);

            styleTableProperties2.Append(tableBorders8);

            style5.Append(styleName5);
            style5.Append(basedOn1);
            style5.Append(rsid39);
            style5.Append(styleTableProperties2);

            styles1.Append(docDefaults1);
            styles1.Append(latentStyles1);
            styles1.Append(style1);
            styles1.Append(style2);
            styles1.Append(style3);
            styles1.Append(style4);
            styles1.Append(style5);

            styleDefinitionsPart1.Styles = styles1;
        }

        // Generates content of customXmlPart1.
        private void GenerateCustomXmlPart1Content(CustomXmlPart customXmlPart1)
        {
            System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(customXmlPart1.GetStream(System.IO.FileMode.Create), System.Text.Encoding.UTF8);
            writer.WriteRaw("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?><b:Sources SelectedStyle=\"\\APA.XSL\" StyleName=\"APA\" xmlns:b=\"http://schemas.openxmlformats.org/officeDocument/2006/bibliography\" xmlns=\"http://schemas.openxmlformats.org/officeDocument/2006/bibliography\"></b:Sources>");
            writer.Flush();
            writer.Close();
        }

        // Generates content of customXmlPropertiesPart1.
        private void GenerateCustomXmlPropertiesPart1Content(CustomXmlPropertiesPart customXmlPropertiesPart1)
        {
            Ds.DataStoreItem dataStoreItem1 = new Ds.DataStoreItem() { ItemId = "{978767D7-5CC5-44EE-9401-BB6DD6CFC4F7}" };
            dataStoreItem1.AddNamespaceDeclaration("ds", "http://schemas.openxmlformats.org/officeDocument/2006/customXml");

            Ds.SchemaReferences schemaReferences1 = new Ds.SchemaReferences();
            Ds.SchemaReference schemaReference1 = new Ds.SchemaReference() { Uri = "http://schemas.openxmlformats.org/officeDocument/2006/bibliography" };

            schemaReferences1.Append(schemaReference1);

            dataStoreItem1.Append(schemaReferences1);

            customXmlPropertiesPart1.DataStoreItem = dataStoreItem1;
        }

        // Generates content of themePart1.
        private void GenerateThemePart1Content(ThemePart themePart1)
        {
            A.Theme theme1 = new A.Theme() { Name = "Тема Office" };
            theme1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

            A.ThemeElements themeElements1 = new A.ThemeElements();

            A.ColorScheme colorScheme1 = new A.ColorScheme() { Name = "Стандартная" };

            A.Dark1Color dark1Color1 = new A.Dark1Color();
            A.SystemColor systemColor1 = new A.SystemColor() { Val = A.SystemColorValues.WindowText, LastColor = "000000" };

            dark1Color1.Append(systemColor1);

            A.Light1Color light1Color1 = new A.Light1Color();
            A.SystemColor systemColor2 = new A.SystemColor() { Val = A.SystemColorValues.Window, LastColor = "FFFFFF" };

            light1Color1.Append(systemColor2);

            A.Dark2Color dark2Color1 = new A.Dark2Color();
            A.RgbColorModelHex rgbColorModelHex1 = new A.RgbColorModelHex() { Val = "44546A" };

            dark2Color1.Append(rgbColorModelHex1);

            A.Light2Color light2Color1 = new A.Light2Color();
            A.RgbColorModelHex rgbColorModelHex2 = new A.RgbColorModelHex() { Val = "E7E6E6" };

            light2Color1.Append(rgbColorModelHex2);

            A.Accent1Color accent1Color1 = new A.Accent1Color();
            A.RgbColorModelHex rgbColorModelHex3 = new A.RgbColorModelHex() { Val = "5B9BD5" };

            accent1Color1.Append(rgbColorModelHex3);

            A.Accent2Color accent2Color1 = new A.Accent2Color();
            A.RgbColorModelHex rgbColorModelHex4 = new A.RgbColorModelHex() { Val = "ED7D31" };

            accent2Color1.Append(rgbColorModelHex4);

            A.Accent3Color accent3Color1 = new A.Accent3Color();
            A.RgbColorModelHex rgbColorModelHex5 = new A.RgbColorModelHex() { Val = "A5A5A5" };

            accent3Color1.Append(rgbColorModelHex5);

            A.Accent4Color accent4Color1 = new A.Accent4Color();
            A.RgbColorModelHex rgbColorModelHex6 = new A.RgbColorModelHex() { Val = "FFC000" };

            accent4Color1.Append(rgbColorModelHex6);

            A.Accent5Color accent5Color1 = new A.Accent5Color();
            A.RgbColorModelHex rgbColorModelHex7 = new A.RgbColorModelHex() { Val = "4472C4" };

            accent5Color1.Append(rgbColorModelHex7);

            A.Accent6Color accent6Color1 = new A.Accent6Color();
            A.RgbColorModelHex rgbColorModelHex8 = new A.RgbColorModelHex() { Val = "70AD47" };

            accent6Color1.Append(rgbColorModelHex8);

            A.Hyperlink hyperlink1 = new A.Hyperlink();
            A.RgbColorModelHex rgbColorModelHex9 = new A.RgbColorModelHex() { Val = "0563C1" };

            hyperlink1.Append(rgbColorModelHex9);

            A.FollowedHyperlinkColor followedHyperlinkColor1 = new A.FollowedHyperlinkColor();
            A.RgbColorModelHex rgbColorModelHex10 = new A.RgbColorModelHex() { Val = "954F72" };

            followedHyperlinkColor1.Append(rgbColorModelHex10);

            colorScheme1.Append(dark1Color1);
            colorScheme1.Append(light1Color1);
            colorScheme1.Append(dark2Color1);
            colorScheme1.Append(light2Color1);
            colorScheme1.Append(accent1Color1);
            colorScheme1.Append(accent2Color1);
            colorScheme1.Append(accent3Color1);
            colorScheme1.Append(accent4Color1);
            colorScheme1.Append(accent5Color1);
            colorScheme1.Append(accent6Color1);
            colorScheme1.Append(hyperlink1);
            colorScheme1.Append(followedHyperlinkColor1);

            A.FontScheme fontScheme1 = new A.FontScheme() { Name = "Стандартная" };

            A.MajorFont majorFont1 = new A.MajorFont();
            A.LatinFont latinFont1 = new A.LatinFont() { Typeface = "Calibri Light", Panose = "020F0302020204030204" };
            A.EastAsianFont eastAsianFont1 = new A.EastAsianFont() { Typeface = "" };
            A.ComplexScriptFont complexScriptFont1 = new A.ComplexScriptFont() { Typeface = "" };
            A.SupplementalFont supplementalFont1 = new A.SupplementalFont() { Script = "Jpan", Typeface = "游ゴシック Light" };
            A.SupplementalFont supplementalFont2 = new A.SupplementalFont() { Script = "Hang", Typeface = "맑은 고딕" };
            A.SupplementalFont supplementalFont3 = new A.SupplementalFont() { Script = "Hans", Typeface = "等线 Light" };
            A.SupplementalFont supplementalFont4 = new A.SupplementalFont() { Script = "Hant", Typeface = "新細明體" };
            A.SupplementalFont supplementalFont5 = new A.SupplementalFont() { Script = "Arab", Typeface = "Times New Roman" };
            A.SupplementalFont supplementalFont6 = new A.SupplementalFont() { Script = "Hebr", Typeface = "Times New Roman" };
            A.SupplementalFont supplementalFont7 = new A.SupplementalFont() { Script = "Thai", Typeface = "Angsana New" };
            A.SupplementalFont supplementalFont8 = new A.SupplementalFont() { Script = "Ethi", Typeface = "Nyala" };
            A.SupplementalFont supplementalFont9 = new A.SupplementalFont() { Script = "Beng", Typeface = "Vrinda" };
            A.SupplementalFont supplementalFont10 = new A.SupplementalFont() { Script = "Gujr", Typeface = "Shruti" };
            A.SupplementalFont supplementalFont11 = new A.SupplementalFont() { Script = "Khmr", Typeface = "MoolBoran" };
            A.SupplementalFont supplementalFont12 = new A.SupplementalFont() { Script = "Knda", Typeface = "Tunga" };
            A.SupplementalFont supplementalFont13 = new A.SupplementalFont() { Script = "Guru", Typeface = "Raavi" };
            A.SupplementalFont supplementalFont14 = new A.SupplementalFont() { Script = "Cans", Typeface = "Euphemia" };
            A.SupplementalFont supplementalFont15 = new A.SupplementalFont() { Script = "Cher", Typeface = "Plantagenet Cherokee" };
            A.SupplementalFont supplementalFont16 = new A.SupplementalFont() { Script = "Yiii", Typeface = "Microsoft Yi Baiti" };
            A.SupplementalFont supplementalFont17 = new A.SupplementalFont() { Script = "Tibt", Typeface = "Microsoft Himalaya" };
            A.SupplementalFont supplementalFont18 = new A.SupplementalFont() { Script = "Thaa", Typeface = "MV Boli" };
            A.SupplementalFont supplementalFont19 = new A.SupplementalFont() { Script = "Deva", Typeface = "Mangal" };
            A.SupplementalFont supplementalFont20 = new A.SupplementalFont() { Script = "Telu", Typeface = "Gautami" };
            A.SupplementalFont supplementalFont21 = new A.SupplementalFont() { Script = "Taml", Typeface = "Latha" };
            A.SupplementalFont supplementalFont22 = new A.SupplementalFont() { Script = "Syrc", Typeface = "Estrangelo Edessa" };
            A.SupplementalFont supplementalFont23 = new A.SupplementalFont() { Script = "Orya", Typeface = "Kalinga" };
            A.SupplementalFont supplementalFont24 = new A.SupplementalFont() { Script = "Mlym", Typeface = "Kartika" };
            A.SupplementalFont supplementalFont25 = new A.SupplementalFont() { Script = "Laoo", Typeface = "DokChampa" };
            A.SupplementalFont supplementalFont26 = new A.SupplementalFont() { Script = "Sinh", Typeface = "Iskoola Pota" };
            A.SupplementalFont supplementalFont27 = new A.SupplementalFont() { Script = "Mong", Typeface = "Mongolian Baiti" };
            A.SupplementalFont supplementalFont28 = new A.SupplementalFont() { Script = "Viet", Typeface = "Times New Roman" };
            A.SupplementalFont supplementalFont29 = new A.SupplementalFont() { Script = "Uigh", Typeface = "Microsoft Uighur" };
            A.SupplementalFont supplementalFont30 = new A.SupplementalFont() { Script = "Geor", Typeface = "Sylfaen" };

            majorFont1.Append(latinFont1);
            majorFont1.Append(eastAsianFont1);
            majorFont1.Append(complexScriptFont1);
            majorFont1.Append(supplementalFont1);
            majorFont1.Append(supplementalFont2);
            majorFont1.Append(supplementalFont3);
            majorFont1.Append(supplementalFont4);
            majorFont1.Append(supplementalFont5);
            majorFont1.Append(supplementalFont6);
            majorFont1.Append(supplementalFont7);
            majorFont1.Append(supplementalFont8);
            majorFont1.Append(supplementalFont9);
            majorFont1.Append(supplementalFont10);
            majorFont1.Append(supplementalFont11);
            majorFont1.Append(supplementalFont12);
            majorFont1.Append(supplementalFont13);
            majorFont1.Append(supplementalFont14);
            majorFont1.Append(supplementalFont15);
            majorFont1.Append(supplementalFont16);
            majorFont1.Append(supplementalFont17);
            majorFont1.Append(supplementalFont18);
            majorFont1.Append(supplementalFont19);
            majorFont1.Append(supplementalFont20);
            majorFont1.Append(supplementalFont21);
            majorFont1.Append(supplementalFont22);
            majorFont1.Append(supplementalFont23);
            majorFont1.Append(supplementalFont24);
            majorFont1.Append(supplementalFont25);
            majorFont1.Append(supplementalFont26);
            majorFont1.Append(supplementalFont27);
            majorFont1.Append(supplementalFont28);
            majorFont1.Append(supplementalFont29);
            majorFont1.Append(supplementalFont30);

            A.MinorFont minorFont1 = new A.MinorFont();
            A.LatinFont latinFont2 = new A.LatinFont() { Typeface = "Calibri", Panose = "020F0502020204030204" };
            A.EastAsianFont eastAsianFont2 = new A.EastAsianFont() { Typeface = "" };
            A.ComplexScriptFont complexScriptFont2 = new A.ComplexScriptFont() { Typeface = "" };
            A.SupplementalFont supplementalFont31 = new A.SupplementalFont() { Script = "Jpan", Typeface = "游明朝" };
            A.SupplementalFont supplementalFont32 = new A.SupplementalFont() { Script = "Hang", Typeface = "맑은 고딕" };
            A.SupplementalFont supplementalFont33 = new A.SupplementalFont() { Script = "Hans", Typeface = "等线" };
            A.SupplementalFont supplementalFont34 = new A.SupplementalFont() { Script = "Hant", Typeface = "新細明體" };
            A.SupplementalFont supplementalFont35 = new A.SupplementalFont() { Script = "Arab", Typeface = "Arial" };
            A.SupplementalFont supplementalFont36 = new A.SupplementalFont() { Script = "Hebr", Typeface = "Arial" };
            A.SupplementalFont supplementalFont37 = new A.SupplementalFont() { Script = "Thai", Typeface = "Cordia New" };
            A.SupplementalFont supplementalFont38 = new A.SupplementalFont() { Script = "Ethi", Typeface = "Nyala" };
            A.SupplementalFont supplementalFont39 = new A.SupplementalFont() { Script = "Beng", Typeface = "Vrinda" };
            A.SupplementalFont supplementalFont40 = new A.SupplementalFont() { Script = "Gujr", Typeface = "Shruti" };
            A.SupplementalFont supplementalFont41 = new A.SupplementalFont() { Script = "Khmr", Typeface = "DaunPenh" };
            A.SupplementalFont supplementalFont42 = new A.SupplementalFont() { Script = "Knda", Typeface = "Tunga" };
            A.SupplementalFont supplementalFont43 = new A.SupplementalFont() { Script = "Guru", Typeface = "Raavi" };
            A.SupplementalFont supplementalFont44 = new A.SupplementalFont() { Script = "Cans", Typeface = "Euphemia" };
            A.SupplementalFont supplementalFont45 = new A.SupplementalFont() { Script = "Cher", Typeface = "Plantagenet Cherokee" };
            A.SupplementalFont supplementalFont46 = new A.SupplementalFont() { Script = "Yiii", Typeface = "Microsoft Yi Baiti" };
            A.SupplementalFont supplementalFont47 = new A.SupplementalFont() { Script = "Tibt", Typeface = "Microsoft Himalaya" };
            A.SupplementalFont supplementalFont48 = new A.SupplementalFont() { Script = "Thaa", Typeface = "MV Boli" };
            A.SupplementalFont supplementalFont49 = new A.SupplementalFont() { Script = "Deva", Typeface = "Mangal" };
            A.SupplementalFont supplementalFont50 = new A.SupplementalFont() { Script = "Telu", Typeface = "Gautami" };
            A.SupplementalFont supplementalFont51 = new A.SupplementalFont() { Script = "Taml", Typeface = "Latha" };
            A.SupplementalFont supplementalFont52 = new A.SupplementalFont() { Script = "Syrc", Typeface = "Estrangelo Edessa" };
            A.SupplementalFont supplementalFont53 = new A.SupplementalFont() { Script = "Orya", Typeface = "Kalinga" };
            A.SupplementalFont supplementalFont54 = new A.SupplementalFont() { Script = "Mlym", Typeface = "Kartika" };
            A.SupplementalFont supplementalFont55 = new A.SupplementalFont() { Script = "Laoo", Typeface = "DokChampa" };
            A.SupplementalFont supplementalFont56 = new A.SupplementalFont() { Script = "Sinh", Typeface = "Iskoola Pota" };
            A.SupplementalFont supplementalFont57 = new A.SupplementalFont() { Script = "Mong", Typeface = "Mongolian Baiti" };
            A.SupplementalFont supplementalFont58 = new A.SupplementalFont() { Script = "Viet", Typeface = "Arial" };
            A.SupplementalFont supplementalFont59 = new A.SupplementalFont() { Script = "Uigh", Typeface = "Microsoft Uighur" };
            A.SupplementalFont supplementalFont60 = new A.SupplementalFont() { Script = "Geor", Typeface = "Sylfaen" };

            minorFont1.Append(latinFont2);
            minorFont1.Append(eastAsianFont2);
            minorFont1.Append(complexScriptFont2);
            minorFont1.Append(supplementalFont31);
            minorFont1.Append(supplementalFont32);
            minorFont1.Append(supplementalFont33);
            minorFont1.Append(supplementalFont34);
            minorFont1.Append(supplementalFont35);
            minorFont1.Append(supplementalFont36);
            minorFont1.Append(supplementalFont37);
            minorFont1.Append(supplementalFont38);
            minorFont1.Append(supplementalFont39);
            minorFont1.Append(supplementalFont40);
            minorFont1.Append(supplementalFont41);
            minorFont1.Append(supplementalFont42);
            minorFont1.Append(supplementalFont43);
            minorFont1.Append(supplementalFont44);
            minorFont1.Append(supplementalFont45);
            minorFont1.Append(supplementalFont46);
            minorFont1.Append(supplementalFont47);
            minorFont1.Append(supplementalFont48);
            minorFont1.Append(supplementalFont49);
            minorFont1.Append(supplementalFont50);
            minorFont1.Append(supplementalFont51);
            minorFont1.Append(supplementalFont52);
            minorFont1.Append(supplementalFont53);
            minorFont1.Append(supplementalFont54);
            minorFont1.Append(supplementalFont55);
            minorFont1.Append(supplementalFont56);
            minorFont1.Append(supplementalFont57);
            minorFont1.Append(supplementalFont58);
            minorFont1.Append(supplementalFont59);
            minorFont1.Append(supplementalFont60);

            fontScheme1.Append(majorFont1);
            fontScheme1.Append(minorFont1);

            A.FormatScheme formatScheme1 = new A.FormatScheme() { Name = "Стандартная" };

            A.FillStyleList fillStyleList1 = new A.FillStyleList();

            A.SolidFill solidFill1 = new A.SolidFill();
            A.SchemeColor schemeColor1 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill1.Append(schemeColor1);

            A.GradientFill gradientFill1 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList1 = new A.GradientStopList();

            A.GradientStop gradientStop1 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor2 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.LuminanceModulation luminanceModulation1 = new A.LuminanceModulation() { Val = 110000 };
            A.SaturationModulation saturationModulation1 = new A.SaturationModulation() { Val = 105000 };
            A.Tint tint1 = new A.Tint() { Val = 67000 };

            schemeColor2.Append(luminanceModulation1);
            schemeColor2.Append(saturationModulation1);
            schemeColor2.Append(tint1);

            gradientStop1.Append(schemeColor2);

            A.GradientStop gradientStop2 = new A.GradientStop() { Position = 50000 };

            A.SchemeColor schemeColor3 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.LuminanceModulation luminanceModulation2 = new A.LuminanceModulation() { Val = 105000 };
            A.SaturationModulation saturationModulation2 = new A.SaturationModulation() { Val = 103000 };
            A.Tint tint2 = new A.Tint() { Val = 73000 };

            schemeColor3.Append(luminanceModulation2);
            schemeColor3.Append(saturationModulation2);
            schemeColor3.Append(tint2);

            gradientStop2.Append(schemeColor3);

            A.GradientStop gradientStop3 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor4 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.LuminanceModulation luminanceModulation3 = new A.LuminanceModulation() { Val = 105000 };
            A.SaturationModulation saturationModulation3 = new A.SaturationModulation() { Val = 109000 };
            A.Tint tint3 = new A.Tint() { Val = 81000 };

            schemeColor4.Append(luminanceModulation3);
            schemeColor4.Append(saturationModulation3);
            schemeColor4.Append(tint3);

            gradientStop3.Append(schemeColor4);

            gradientStopList1.Append(gradientStop1);
            gradientStopList1.Append(gradientStop2);
            gradientStopList1.Append(gradientStop3);
            A.LinearGradientFill linearGradientFill1 = new A.LinearGradientFill() { Angle = 5400000, Scaled = false };

            gradientFill1.Append(gradientStopList1);
            gradientFill1.Append(linearGradientFill1);

            A.GradientFill gradientFill2 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList2 = new A.GradientStopList();

            A.GradientStop gradientStop4 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor5 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.SaturationModulation saturationModulation4 = new A.SaturationModulation() { Val = 103000 };
            A.LuminanceModulation luminanceModulation4 = new A.LuminanceModulation() { Val = 102000 };
            A.Tint tint4 = new A.Tint() { Val = 94000 };

            schemeColor5.Append(saturationModulation4);
            schemeColor5.Append(luminanceModulation4);
            schemeColor5.Append(tint4);

            gradientStop4.Append(schemeColor5);

            A.GradientStop gradientStop5 = new A.GradientStop() { Position = 50000 };

            A.SchemeColor schemeColor6 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.SaturationModulation saturationModulation5 = new A.SaturationModulation() { Val = 110000 };
            A.LuminanceModulation luminanceModulation5 = new A.LuminanceModulation() { Val = 100000 };
            A.Shade shade1 = new A.Shade() { Val = 100000 };

            schemeColor6.Append(saturationModulation5);
            schemeColor6.Append(luminanceModulation5);
            schemeColor6.Append(shade1);

            gradientStop5.Append(schemeColor6);

            A.GradientStop gradientStop6 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor7 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.LuminanceModulation luminanceModulation6 = new A.LuminanceModulation() { Val = 99000 };
            A.SaturationModulation saturationModulation6 = new A.SaturationModulation() { Val = 120000 };
            A.Shade shade2 = new A.Shade() { Val = 78000 };

            schemeColor7.Append(luminanceModulation6);
            schemeColor7.Append(saturationModulation6);
            schemeColor7.Append(shade2);

            gradientStop6.Append(schemeColor7);

            gradientStopList2.Append(gradientStop4);
            gradientStopList2.Append(gradientStop5);
            gradientStopList2.Append(gradientStop6);
            A.LinearGradientFill linearGradientFill2 = new A.LinearGradientFill() { Angle = 5400000, Scaled = false };

            gradientFill2.Append(gradientStopList2);
            gradientFill2.Append(linearGradientFill2);

            fillStyleList1.Append(solidFill1);
            fillStyleList1.Append(gradientFill1);
            fillStyleList1.Append(gradientFill2);

            A.LineStyleList lineStyleList1 = new A.LineStyleList();

            A.Outline outline1 = new A.Outline() { Width = 6350, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill2 = new A.SolidFill();
            A.SchemeColor schemeColor8 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill2.Append(schemeColor8);
            A.PresetDash presetDash1 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };
            A.Miter miter1 = new A.Miter() { Limit = 800000 };

            outline1.Append(solidFill2);
            outline1.Append(presetDash1);
            outline1.Append(miter1);

            A.Outline outline2 = new A.Outline() { Width = 12700, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill3 = new A.SolidFill();
            A.SchemeColor schemeColor9 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill3.Append(schemeColor9);
            A.PresetDash presetDash2 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };
            A.Miter miter2 = new A.Miter() { Limit = 800000 };

            outline2.Append(solidFill3);
            outline2.Append(presetDash2);
            outline2.Append(miter2);

            A.Outline outline3 = new A.Outline() { Width = 19050, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill4 = new A.SolidFill();
            A.SchemeColor schemeColor10 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill4.Append(schemeColor10);
            A.PresetDash presetDash3 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };
            A.Miter miter3 = new A.Miter() { Limit = 800000 };

            outline3.Append(solidFill4);
            outline3.Append(presetDash3);
            outline3.Append(miter3);

            lineStyleList1.Append(outline1);
            lineStyleList1.Append(outline2);
            lineStyleList1.Append(outline3);

            A.EffectStyleList effectStyleList1 = new A.EffectStyleList();

            A.EffectStyle effectStyle1 = new A.EffectStyle();
            A.EffectList effectList1 = new A.EffectList();

            effectStyle1.Append(effectList1);

            A.EffectStyle effectStyle2 = new A.EffectStyle();
            A.EffectList effectList2 = new A.EffectList();

            effectStyle2.Append(effectList2);

            A.EffectStyle effectStyle3 = new A.EffectStyle();

            A.EffectList effectList3 = new A.EffectList();

            A.OuterShadow outerShadow1 = new A.OuterShadow() { BlurRadius = 57150L, Distance = 19050L, Direction = 5400000, Alignment = A.RectangleAlignmentValues.Center, RotateWithShape = false };

            A.RgbColorModelHex rgbColorModelHex11 = new A.RgbColorModelHex() { Val = "000000" };
            A.Alpha alpha1 = new A.Alpha() { Val = 63000 };

            rgbColorModelHex11.Append(alpha1);

            outerShadow1.Append(rgbColorModelHex11);

            effectList3.Append(outerShadow1);

            effectStyle3.Append(effectList3);

            effectStyleList1.Append(effectStyle1);
            effectStyleList1.Append(effectStyle2);
            effectStyleList1.Append(effectStyle3);

            A.BackgroundFillStyleList backgroundFillStyleList1 = new A.BackgroundFillStyleList();

            A.SolidFill solidFill5 = new A.SolidFill();
            A.SchemeColor schemeColor11 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill5.Append(schemeColor11);

            A.SolidFill solidFill6 = new A.SolidFill();

            A.SchemeColor schemeColor12 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint5 = new A.Tint() { Val = 95000 };
            A.SaturationModulation saturationModulation7 = new A.SaturationModulation() { Val = 170000 };

            schemeColor12.Append(tint5);
            schemeColor12.Append(saturationModulation7);

            solidFill6.Append(schemeColor12);

            A.GradientFill gradientFill3 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList3 = new A.GradientStopList();

            A.GradientStop gradientStop7 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor13 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint6 = new A.Tint() { Val = 93000 };
            A.SaturationModulation saturationModulation8 = new A.SaturationModulation() { Val = 150000 };
            A.Shade shade3 = new A.Shade() { Val = 98000 };
            A.LuminanceModulation luminanceModulation7 = new A.LuminanceModulation() { Val = 102000 };

            schemeColor13.Append(tint6);
            schemeColor13.Append(saturationModulation8);
            schemeColor13.Append(shade3);
            schemeColor13.Append(luminanceModulation7);

            gradientStop7.Append(schemeColor13);

            A.GradientStop gradientStop8 = new A.GradientStop() { Position = 50000 };

            A.SchemeColor schemeColor14 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint7 = new A.Tint() { Val = 98000 };
            A.SaturationModulation saturationModulation9 = new A.SaturationModulation() { Val = 130000 };
            A.Shade shade4 = new A.Shade() { Val = 90000 };
            A.LuminanceModulation luminanceModulation8 = new A.LuminanceModulation() { Val = 103000 };

            schemeColor14.Append(tint7);
            schemeColor14.Append(saturationModulation9);
            schemeColor14.Append(shade4);
            schemeColor14.Append(luminanceModulation8);

            gradientStop8.Append(schemeColor14);

            A.GradientStop gradientStop9 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor15 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade5 = new A.Shade() { Val = 63000 };
            A.SaturationModulation saturationModulation10 = new A.SaturationModulation() { Val = 120000 };

            schemeColor15.Append(shade5);
            schemeColor15.Append(saturationModulation10);

            gradientStop9.Append(schemeColor15);

            gradientStopList3.Append(gradientStop7);
            gradientStopList3.Append(gradientStop8);
            gradientStopList3.Append(gradientStop9);
            A.LinearGradientFill linearGradientFill3 = new A.LinearGradientFill() { Angle = 5400000, Scaled = false };

            gradientFill3.Append(gradientStopList3);
            gradientFill3.Append(linearGradientFill3);

            backgroundFillStyleList1.Append(solidFill5);
            backgroundFillStyleList1.Append(solidFill6);
            backgroundFillStyleList1.Append(gradientFill3);

            formatScheme1.Append(fillStyleList1);
            formatScheme1.Append(lineStyleList1);
            formatScheme1.Append(effectStyleList1);
            formatScheme1.Append(backgroundFillStyleList1);

            themeElements1.Append(colorScheme1);
            themeElements1.Append(fontScheme1);
            themeElements1.Append(formatScheme1);
            A.ObjectDefaults objectDefaults1 = new A.ObjectDefaults();
            A.ExtraColorSchemeList extraColorSchemeList1 = new A.ExtraColorSchemeList();

            A.ExtensionList extensionList1 = new A.ExtensionList();

            A.Extension extension1 = new A.Extension() { Uri = "{05A4C25C-085E-4340-85A3-A5531E510DB2}" };

            OpenXmlUnknownElement openXmlUnknownElement3 = OpenXmlUnknownElement.CreateOpenXmlUnknownElement("<thm15:themeFamily xmlns:thm15=\"http://schemas.microsoft.com/office/thememl/2012/main\" name=\"Office Theme\" id=\"{62F939B6-93AF-4DB8-9C6B-D6C7DFDC589F}\" vid=\"{4A3C46E8-61CC-4603-A589-7422A47A8E4A}\" />");

            extension1.Append(openXmlUnknownElement3);

            extensionList1.Append(extension1);

            theme1.Append(themeElements1);
            theme1.Append(objectDefaults1);
            theme1.Append(extraColorSchemeList1);
            theme1.Append(extensionList1);

            themePart1.Theme = theme1;
        }

        // Generates content of fontTablePart1.
        private void GenerateFontTablePart1Content(FontTablePart fontTablePart1)
        {
            Fonts fonts1 = new Fonts() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 w15 w16se" } };
            fonts1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            fonts1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            fonts1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            fonts1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            fonts1.AddNamespaceDeclaration("w15", "http://schemas.microsoft.com/office/word/2012/wordml");
            fonts1.AddNamespaceDeclaration("w16se", "http://schemas.microsoft.com/office/word/2015/wordml/symex");

            Font font1 = new Font() { Name = "Times New Roman" };
            Panose1Number panose1Number1 = new Panose1Number() { Val = "02020603050405020304" };
            FontCharSet fontCharSet1 = new FontCharSet() { Val = "CC" };
            FontFamily fontFamily1 = new FontFamily() { Val = FontFamilyValues.Roman };
            Pitch pitch1 = new Pitch() { Val = FontPitchValues.Variable };
            FontSignature fontSignature1 = new FontSignature() { UnicodeSignature0 = "E0002AFF", UnicodeSignature1 = "C0007841", UnicodeSignature2 = "00000009", UnicodeSignature3 = "00000000", CodePageSignature0 = "000001FF", CodePageSignature1 = "00000000" };

            font1.Append(panose1Number1);
            font1.Append(fontCharSet1);
            font1.Append(fontFamily1);
            font1.Append(pitch1);
            font1.Append(fontSignature1);

            Font font2 = new Font() { Name = "Calibri Light" };
            Panose1Number panose1Number2 = new Panose1Number() { Val = "020F0302020204030204" };
            FontCharSet fontCharSet2 = new FontCharSet() { Val = "CC" };
            FontFamily fontFamily2 = new FontFamily() { Val = FontFamilyValues.Swiss };
            Pitch pitch2 = new Pitch() { Val = FontPitchValues.Variable };
            FontSignature fontSignature2 = new FontSignature() { UnicodeSignature0 = "A00002EF", UnicodeSignature1 = "4000207B", UnicodeSignature2 = "00000000", UnicodeSignature3 = "00000000", CodePageSignature0 = "0000019F", CodePageSignature1 = "00000000" };

            font2.Append(panose1Number2);
            font2.Append(fontCharSet2);
            font2.Append(fontFamily2);
            font2.Append(pitch2);
            font2.Append(fontSignature2);

            Font font3 = new Font() { Name = "Calibri" };
            Panose1Number panose1Number3 = new Panose1Number() { Val = "020F0502020204030204" };
            FontCharSet fontCharSet3 = new FontCharSet() { Val = "CC" };
            FontFamily fontFamily3 = new FontFamily() { Val = FontFamilyValues.Swiss };
            Pitch pitch3 = new Pitch() { Val = FontPitchValues.Variable };
            FontSignature fontSignature3 = new FontSignature() { UnicodeSignature0 = "E00002FF", UnicodeSignature1 = "4000ACFF", UnicodeSignature2 = "00000001", UnicodeSignature3 = "00000000", CodePageSignature0 = "0000019F", CodePageSignature1 = "00000000" };

            font3.Append(panose1Number3);
            font3.Append(fontCharSet3);
            font3.Append(fontFamily3);
            font3.Append(pitch3);
            font3.Append(fontSignature3);

            fonts1.Append(font1);
            fonts1.Append(font2);
            fonts1.Append(font3);

            fontTablePart1.Fonts = fonts1;
        }

        // Generates content of webSettingsPart1.
        private void GenerateWebSettingsPart1Content(WebSettingsPart webSettingsPart1)
        {
            WebSettings webSettings1 = new WebSettings() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 w15 w16se" } };
            webSettings1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            webSettings1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            webSettings1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            webSettings1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            webSettings1.AddNamespaceDeclaration("w15", "http://schemas.microsoft.com/office/word/2012/wordml");
            webSettings1.AddNamespaceDeclaration("w16se", "http://schemas.microsoft.com/office/word/2015/wordml/symex");

            Divs divs1 = new Divs();

            Div div1 = new Div() { Id = "1715234125" };
            BodyDiv bodyDiv1 = new BodyDiv() { Val = true };
            LeftMarginDiv leftMarginDiv1 = new LeftMarginDiv() { Val = "0" };
            RightMarginDiv rightMarginDiv1 = new RightMarginDiv() { Val = "0" };
            TopMarginDiv topMarginDiv1 = new TopMarginDiv() { Val = "0" };
            BottomMarginDiv bottomMarginDiv1 = new BottomMarginDiv() { Val = "0" };

            DivBorder divBorder1 = new DivBorder();
            TopBorder topBorder234 = new TopBorder() { Val = BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
            LeftBorder leftBorder225 = new LeftBorder() { Val = BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
            BottomBorder bottomBorder240 = new BottomBorder() { Val = BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };
            RightBorder rightBorder225 = new RightBorder() { Val = BorderValues.None, Color = "auto", Size = (UInt32Value)0U, Space = (UInt32Value)0U };

            divBorder1.Append(topBorder234);
            divBorder1.Append(leftBorder225);
            divBorder1.Append(bottomBorder240);
            divBorder1.Append(rightBorder225);

            div1.Append(bodyDiv1);
            div1.Append(leftMarginDiv1);
            div1.Append(rightMarginDiv1);
            div1.Append(topMarginDiv1);
            div1.Append(bottomMarginDiv1);
            div1.Append(divBorder1);

            divs1.Append(div1);
            OptimizeForBrowser optimizeForBrowser1 = new OptimizeForBrowser();
            TargetScreenSize targetScreenSize1 = new TargetScreenSize() { Val = TargetScreenSizeValues.Sz800x600 };

            webSettings1.Append(divs1);
            webSettings1.Append(optimizeForBrowser1);
            webSettings1.Append(targetScreenSize1);

            webSettingsPart1.WebSettings = webSettings1;
        }

        private void SetPackageProperties(OpenXmlPackage document)
        {
            document.PackageProperties.Creator = "admin";
            document.PackageProperties.Title = "Приложение 8";
            document.PackageProperties.Subject = "";
            document.PackageProperties.Keywords = "";
            document.PackageProperties.Description = "";
            document.PackageProperties.Revision = "2";
            document.PackageProperties.Created = System.Xml.XmlConvert.ToDateTime("2017-10-17T14:03:00Z", System.Xml.XmlDateTimeSerializationMode.RoundtripKind);
            document.PackageProperties.Modified = System.Xml.XmlConvert.ToDateTime("2017-10-17T14:03:00Z", System.Xml.XmlDateTimeSerializationMode.RoundtripKind);
            document.PackageProperties.LastModifiedBy = "Антон";
            document.PackageProperties.LastPrinted = System.Xml.XmlConvert.ToDateTime("2007-09-23T12:02:00Z", System.Xml.XmlDateTimeSerializationMode.RoundtripKind);
        }

    }
}
