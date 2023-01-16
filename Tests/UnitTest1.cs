using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit.Sdk;
using System;
using Sudoku;
using Sudoku.BoardClasses;
using Sudoku.Exceptions;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        //Illegal element position exception
        public void TestMethod1()
        {
            string sudokuString = "770010006000805210001306900304000600062053071900408025009700502700000004120000739";
            int sudokuWidth = (int)Math.Sqrt(sudokuString.Length);
            Board board = new Board(sudokuString, sudokuWidth);
            Assert.ThrowsException<IllegalElementPositionException>(() => { SolveBoard.Solving(board, sudokuString); });
        }

        [TestMethod]
        //Illegal element value exception
        public void TestMethod2()
        {
            string sudokuString = "AAA010006000805210001306900304000600062053071900408025009700502700000004120000739";
            int sudokuWidth = (int)Math.Sqrt(sudokuString.Length);
            Board board = new Board(sudokuString, sudokuWidth);
            Assert.ThrowsException<IllegalElementValueException>(() => { SolveBoard.Solving(board, sudokuString); });
        }

        [TestMethod]
        public void TestMethod3()
        //Illegal length exception
        {
            string sudokuString = "07001000600080521000130690030400060006205307190040802500970";
            int sudokuWidth = (int)Math.Sqrt(sudokuString.Length);
            Board board = new Board(sudokuString, sudokuWidth);
            Assert.ThrowsException<IllegalLengthException>(() => { SolveBoard.Solving(board, sudokuString); });
        }

        [TestMethod]
        //9X9 sudoku board
        public void TestMethod4()
        {
            string sudokuString = "070010006000805210001306900304000600062053071900408025009700502700000004120000739";
            int sudokuWidth = (int)Math.Sqrt(sudokuString.Length);
            Board board = new Board(sudokuString, sudokuWidth);
            string result = SolveBoard.Solving(board, sudokuString);
            Assert.IsTrue(result.Equals("573219846496875213281346957354127698862953471917468325649731582738592164125684739"));
        }

        [TestMethod]
        //9X9 sudoku board
        public void TestMethod5()
        {
            string sudokuString = "030107800000025760000000000400000000000482000000709600900001506000000000000200009";
            int sudokuWidth = (int)Math.Sqrt(sudokuString.Length);
            Board board = new Board(sudokuString, sudokuWidth);
            string result = SolveBoard.Solving(board, sudokuString);
            Assert.IsTrue(result.Equals("536147892149825763728693145493516287657482931812739654984371526261954378375268419"));
        }
        
        [TestMethod]
        //9X9 empty sudoku board
        public void TestMethod6()
        {
            string sudokuString = "000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            int sudokuWidth = (int)Math.Sqrt(sudokuString.Length);
            Board board = new Board(sudokuString, sudokuWidth);
            string result = SolveBoard.Solving(board, sudokuString);
            Assert.IsTrue(result.Equals("123456789687139254495278136712893465956714823348625917261347598879561342534982671"));
        }

        [TestMethod]
        //1X1 empty sudoku board
        public void TestMethod7()
        {
            string sudokuString = "0";
            int sudokuWidth = (int)Math.Sqrt(sudokuString.Length);
            Board board = new Board(sudokuString, sudokuWidth);
            string result = SolveBoard.Solving(board, sudokuString);
            Assert.IsTrue(result.Equals("1"));
        }

        [TestMethod]
        //4X4 empty sudoku board
        public void TestMethod8()
        {
            string sudokuString = "0100000004000020";
            int sudokuWidth = (int)Math.Sqrt(sudokuString.Length);
            Board board = new Board(sudokuString, sudokuWidth);
            string result = SolveBoard.Solving(board, sudokuString);
            Assert.IsTrue(result.Equals("3142421324311324"));
        }

        [TestMethod]
        //4X4 empty sudoku board
        public void TestMethod9()
        {
            string sudokuString = "0000000000000000";
            int sudokuWidth = (int)Math.Sqrt(sudokuString.Length);
            Board board = new Board(sudokuString, sudokuWidth);
            string result = SolveBoard.Solving(board, sudokuString);
            Assert.IsTrue(result.Equals("1234341221434321"));
        }

        [TestMethod]
        //16X16 example sudoku board
        public void TestMethod10()
        {
            string sudokuString = "10023400<06000700080007003009:6;0<00:0010=0;00>0300?200>000900<0=000800:0<201?000;76000@000?005=000:05?0040800;0@0059<00100000800200000=00<580030=00?0300>80@000580010002000=9?000<406@0=00700050300<0006004;00@0700@050>0010020;1?900=002000>000>000;0200=3500<";
            int sudokuWidth = (int)Math.Sqrt(sudokuString.Length);
            Board board = new Board(sudokuString, sudokuWidth);
            string result = SolveBoard.Solving(board, sudokuString);
            Assert.IsTrue(result.Equals("15:2349;<@6>?=78>@8=5?7<43129:6;9<47:@618=?;35>236;?2=8>75:94@<1=4>387;:5<261?@98;76412@9:>?<35=<91:=5?634@8>2;7@?259<>31;7=:68462@>;94=?1<587:37=91?235;>8:@<46583;1:<7264@=9?>?:<4>6@8=9372;152358<>:?6794;1=@:7=<@359>8;1642?;1?968=4@25<7>3:4>6@7;12:?=3589<"));
        }

        [TestMethod]
        //16X16 example sudoku board
        public void TestMethod11()
        {
            string sudokuString = "<0000000000;0000000000000000456000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000090000000000000000>=00000000000000000014000000000000000000000000:00000000000000000000000000000000?0000";
            int sudokuWidth = (int)Math.Sqrt(sudokuString.Length);
            Board board = new Board(sudokuString, sudokuWidth);
            string result = SolveBoard.Solving(board, sudokuString);
            Assert.IsTrue(result.Equals("<347@>8?956;=:12;=9><12378?:456@:1@?=567<>24;93856284;9:13@=<>7?4><@3615:;9872?=38;972?<6=51:4@>=:?594>;327@618<6712:=@84?><935;7?54>839;:=62@<182:6;<5=>@193?479;312@46?<87>=:5>@=<?:7154328;96146357;@29<>?8=:?58;19<2=6:3@7>4@9>:6?=487;51<232<7=83:>@14?56;9"));
        }

        [TestMethod]
        //16X16 empty sudoku board
        public void TestMethod12()
        {
            string sudokuString = "0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            int sudokuWidth = (int)Math.Sqrt(sudokuString.Length);
            Board board = new Board(sudokuString, sudokuWidth);
            string result = SolveBoard.Solving(board, sudokuString);
            Assert.IsTrue(result.Equals("123456789:;<=>?@?=@714;<368>29:5<;:>2=9?145@368768593:>@27?=14;<9123?@475<>8:;6=:6?;815=@34972<>>@<=926;?17:53484578>3<:=26;@19?3?127<84:>@6;=598<=6@?15;934>72:79>@:;268=15?<3454;:=>39<?278@16236145=>78<?9:@;=:8?67@14;93<5>2@>9<;8:265=14?73;745<9?3>@:268=1"));
        }

        [TestMethod]
        //25X25 sudoku board
        public void TestMethod13()
        {
            string sudokuString = "100000009000000A000000000000000000000000000000000000000000000000000000000000000020000000:000000B000000000000000000000000000000000000000000000000000000000000000030000000;0000000C00000000000000000000000000000000000000000000000000000000000000040000000<00000000D0000000000000000000000000000000000000000000000000000000000000050000000=00000000E0000000000000000000000000000000000000000000000000000000000000060000000>00000000F0000000000000000000000000000000000000000000000000000000000000070000000?0000000G00000000000000000000000000000000000000000000000000000000000000080000000@0000000H0000000I0000000000000000000000000000000000000000";
            int sudokuWidth = (int)Math.Sqrt(sudokuString.Length);
            Board board = new Board(sudokuString, sudokuWidth);
            string result = SolveBoard.Solving(board, sudokuString);
            Assert.IsTrue(result.Equals("1:B@CI>89DE6?GHA324;<5=7FA4H85:BF76D3;<9@E?=C1IG>2I<367@;H=?B8F2A:1G>5DCE94>;=E9214GAIC5:7F<6D8B@H?3DG2F?5E<C31@=>4BI9H7:A;86?>6219DI5:<EGH=8C@F37BA4;<D4I=AC>FG317@695E;B?28:HBCG9F<8;H7>4IA:6?12=@D3E535@HAB=1E4?289;<:>7DF6ICG78E;:?@3625DBCF4AHGI=1><9GA834=:DI>2BH71;@5CE9F?6<C65?H19@4;A:>D<=F83GI7B2E9BF<2C?A8E=I6;3>47:15HDG@@ID=>3F7B59GE4?2H<A6;8C1::7;1E6G2<H@FC85?DIB9>=43A4=?GBDI9:F6H2E>C8;5@3<7A169CDIE5=>B;<A1G37F?24:@H8F21A<;H?@8:735IDG46>CE9B=H3>7@42GA1C=DF8EB:9<6;5I?;E:5876C3<49@?B1=AIH2GFD>21I46>ABD9H?:=@G;CEF83<575@9CDG7:1=F><IEH238?A46;B=?A:;H<E2C8593D76B@4G>1FI8H<>GF36;I7A4BC59=1:E?2@DEF7B3845?@G;162I>D<AH9:=C"));
        }

        [TestMethod]
        //25X25 empty sudoku board
        public void TestMethod14()
        {
            string sudokuString = "000000000000000000000000000000000000AB0000000000000000000000000000000000000000000000000000000000?:6000000000000000000000000000000000000089000000000000000000000000000000000000000000000000000000000000000000000000000000000000000005000000000000000030000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000023000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000007E000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            int sudokuWidth = (int)Math.Sqrt(sudokuString.Length);
            Board board = new Board(sudokuString, sudokuWidth);
            string result = SolveBoard.Solving(board, sudokuString);
            Assert.IsTrue(result.Equals("6:?54AB8;<91=>@7EC3D2FGHI7ECDF36:?>5AB4G2<@HI918;=8;<GI514@F32CDH6:?9=AB7E>3AB92=CDHI7E8;<14>FG5?:6@1=>@H7E92G6:?FIAB58;34<CDF31=BC>GI2@8964<7H?E;5AD:H478>63<B;C?51=FA:D2EG@I9G?E:@4F718H3DA;5=I>9B2C<6I<9ACE:5D?G7F2>46;@BH3=18265;D9@H=AEB<I:C81G37>F?4@C:F5BD>E6;=4983?G7HIA12<?B379<=IC4DF>51E;A28G@6:HAG8I1?237:<HE@6=>BC4D;9F5>D26=85;AH:I3G?9F<1@C7B4EEH4<;G91F@2C7BAI5D6:>83=?C5F1ADH?<E=6@89B23I74:>G;;7@38IAF>=?41H5GCE:<69DB2<9D4:28637A>GEB?H=;1@CI5FBIHE6;G@5CF<:32D94A>8=?71=2G>?:4B91ID;7C8@F56<EH3A51=H7@?E4B896CD>32<F:I;AG98AC3>I=:D45H<F;G7E?162@B4F;?G17263>@I:EHD8BA=<59C:>6BEH<AG51;2?3@I9=CFD487D@I2<F;C89BGA=7:1645?HE>3"));
        }

        [TestMethod]
        //25X25 empty sudoku board
        public void TestMethod15()
        {
            string sudokuString = "0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            int sudokuWidth = (int)Math.Sqrt(sudokuString.Length);
            Board board = new Board(sudokuString, sudokuWidth);
            string result = SolveBoard.Solving(board, sudokuString);
            Assert.IsTrue(result.Equals("123456789:;<=>?@ABCDEFGHIDBGH<15;FI48:EC3?>962@=7AF;8EI2?@CG15DAB4=H7<39:6>9:=>@3DA<H276GF15I8E4?B;C?A67C4>E=B39IH@2:F;G158<DE1234IH5896D<:>;G@A?7BC=FCDIF>@16G?=357H829<B;4AE:=@9BH:27;>F1A8G645ECD3I?<;<AG?D3=EFC4B9I71:H>6258@5678:<4BAC?2@;ED3=IFG1>9H4I123?B958DE><:GCA6;@H7F=GH@<9FI16=BC357ED2?8:>4A;:E?CA>@27;HF1=8BI459<G3D6>8F=;CG3D<IA469H71@:?E25B75D6BHE4:A@G2?;<>3F=I81C934E1289?H5:=;F<A6CB@>IDG7AFCIDG=>167@E35:982HB;<4?H>:@GBFD278I?1A=;<45C693E<=B?8;CI3E9HG46>FD17A:@25695;7A:<4@>BC2D?EG3IF=H182349156F?D<:8C=I@;>AH7EBGIC>AE78GB15;9D3FH6:2=<?@4BGHDF9;CI2E>7@15<?=48A6:3@?<:=EAH>3G6FB4987D15C;I287;56=<:@4A?HI2CBEG39DF>1"));
        }
        
        [TestMethod]
        //4X4 unsolvable board exception
        public void TestMethod16()
        {
            string sudokuString = "300000000000300000000000009000000300000000000000000000000000000000000030000000000";
            int sudokuWidth = (int)Math.Sqrt(sudokuString.Length);
            Board board = new Board(sudokuString, sudokuWidth);
            Assert.ThrowsException<UnsolvableBoardException>(() => { SolveBoard.Solving(board, sudokuString); });
        }
        
        [TestMethod]
        //9X9 unsolvable board exception
        public void TestMethod17()
        {
            string sudokuString = "300000000000300000000000009000000300000000000000000000000000000000000030000000000";
            int sudokuWidth = (int)Math.Sqrt(sudokuString.Length);
            Board board = new Board(sudokuString, sudokuWidth);
            Assert.ThrowsException<UnsolvableBoardException>(() => { SolveBoard.Solving(board, sudokuString); });
        }

        [TestMethod]
        //16X16 unsolvable board exception
        public void TestMethod18()
        {
            string sudokuString = "900000000000000080000000000000007000000000000000600000000000000050000000000000004000000000000000300000000000000000000000000000021000000000000000:000000000000000;000000000000000<0000000000000000>000000000000000=000000000000000@000000000000000?00000000000000";
            int sudokuWidth = (int)Math.Sqrt(sudokuString.Length);
            Board board = new Board(sudokuString, sudokuWidth);
            Assert.ThrowsException<UnsolvableBoardException>(() => { SolveBoard.Solving(board, sudokuString); });
        }

        [TestMethod]
        //9X9 solved board
        public void TestMethod19()
        {
            string sudokuString = "871962345349815726256437891683179254915324687427586913598743162132658479764291538";
            int sudokuWidth = (int)Math.Sqrt(sudokuString.Length);
            Board board = new Board(sudokuString, sudokuWidth);
            string result = SolveBoard.Solving(board, sudokuString);
            Assert.IsTrue(result.Equals("871962345349815726256437891683179254915324687427586913598743162132658479764291538"));
        }
    }
}