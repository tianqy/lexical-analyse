using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace word_analyse
{
    class Analysis
    {
        private static string errors="";
        private static List<Token> list = new List<Token>();
        //private static Token token = new Token();
        private static int lines = 1;
        private static List<int> error_position=new List<int>();

        //分析
        public static List<Token> analyse(string source)
        {
            lines = 1;
            list.Clear();
            errors = "";
            error_position.Clear();
            //运算符1-34
            string[] _operator = new string[34]{"~","+","+=","++","-","-=","--","*","*=","?:","/","/=","%","%="
                ,"&","&=","&&","|","|=","||","!","!=","^","^=","<","<=","<<","<<=",">",">=",">>",">>=","=","=="};
            
            //界限符35-46,注释符//为47
            char[] _bound = new char[12] { '(', ')', '[', ']', ',', ';', '{', '}', '\'', '.', '#', '"' };

            //关键字
            string[] _keyword = new string[50]{"abstract","assert","boolean","break","byte","case","catch","char","class","const",
                "continue","default","do","double","else","enum","extends","final","finally","float",
                "for","goto","if","implements","import","instanceof","int","interface","long","native",
                "new","package","private","protected","public","return","strictfp","short","static","super",
                "switch","synchronized","this","throw","throws","transient","try","void","volatile","while"};
            
            int i=0;
            
            try
            {
                while (i<source.Length)
                {
                    //是否为运算符（1-34）
                    if (_operator.Contains(source[i] + "") || source[i] == '?')
                    {
                        Token token = new Token();
                        switch (source[i])
                        {
                            case '~':   // 1 ~
                                token.Code = 1;
                                token.Value = source[i] + "";
                                list.Add(token);
                                i++;
                                break;

                            case '+':   // 2-4
                                token.Value = source[i] + "";
                                i++;
                                switch (source[i])
                                {
                                    case '+':   // 4 ++
                                        token.Code = 4;
                                        token.Value += source[i];
                                        list.Add(token);
                                        i++;
                                        break;
                                    case '=':   // 3 +=
                                        token.Code = 3;
                                        token.Value += source[i];
                                        list.Add(token);
                                        i++;
                                        break;
                                    default:    // 2 +
                                        token.Code = 2;
                                        list.Add(token);
                                        break;
                                }
                                break;

                            case '-':   // 5-7
                                token.Value = source[i] + "";
                                i++;
                                switch (source[i])
                                {
                                    case '-':   // 7 --
                                        token.Code = 7;
                                        token.Value += source[i];
                                        list.Add(token);
                                        i++;
                                        break;
                                    case '=':   // 6 -=
                                        token.Code = 6;
                                        token.Value += source[i];
                                        list.Add(token);
                                        i++;
                                        break;
                                    default:    // 5 -
                                        token.Code = 5;
                                        list.Add(token);
                                        break;
                                }
                                break;

                            case '*':
                                token.Value = source[i] + "";
                                i++;
                                if (source[i] == '=')   // 9 *=
                                {
                                    token.Code = 9;
                                    token.Value += source[i];
                                    list.Add(token);
                                    i++;
                                }
                                else
                                {// 8 *
                                    token.Code = 8;
                                    list.Add(token);
                                }
                                break;

                            case '?':   // 10 ？：
                                token.Value = source[i] + "";
                                i++;
                                bool flag = false;
                                for (int j = i; j < source.Length; j++)
                                {
                                    if (source[j] == ':')
                                    {
                                        flag = true;
                                        break;
                                    }
                                }
                                if (flag)
                                {
                                    token.Value += ":";
                                    token.Code = 10;
                                    list.Add(token);
                                }
                                else
                                {
                                    token.Code = -1;
                                    list.Add(token);
                                    errors += "error in position " + (i-1) + ", lines: " + lines + ". " + source[i-1] + "无法单独识别,建议与 : 搭配使用\r\n";
                                    error_position.Add(i-1);
                                }
                                break;

                            case '/':   //11-12,47
                                token.Value = source[i] + "";
                                i++;
                                if (source[i] == '=')   // 12 /=
                                {
                                    token.Code = 12;
                                    token.Value += source[i];
                                    list.Add(token);
                                    i++;
                                }
                                else if (source[i] == '/')
                                {
                                    token.Code = 47;
                                    token.Value += source[i];
                                    list.Add(token);
                                    for (i = i + 1; i < source.Length; i++)
                                    {
                                        if (source[i] == '\n')
                                        {
                                            i++;
                                            break;
                                        }
                                    }
                                }
                                else
                                {// 11 /
                                    token.Code = 11;
                                    list.Add(token);
                                }
                                break;

                            case '%':   //13-14
                                token.Value = source[i] + "";
                                i++;
                                if (source[i] == '=')   // 14 %=
                                {
                                    token.Code = 14;
                                    token.Value += source[i];
                                    list.Add(token);
                                    i++;
                                }
                                else
                                {// 13 %
                                    token.Code = 13;
                                    list.Add(token);
                                }
                                break;

                            case '&':   //15-17
                                token.Value = source[i] + "";
                                i++;
                                switch (source[i])
                                {
                                    case '&':   // 17 &&
                                        token.Code = 17;
                                        token.Value += source[i];
                                        list.Add(token);
                                        i++;
                                        break;
                                    case '=':   // 16 &=
                                        token.Code = 16;
                                        token.Value += source[i];
                                        list.Add(token);
                                        i++;
                                        break;
                                    default:    // 15 &
                                        token.Code = 15;
                                        list.Add(token);
                                        break;
                                }
                                break;

                            case '|':   //18-20
                                token.Value = source[i] + "";
                                i++;
                                switch (source[i])
                                {
                                    case '|':   // 20 ||
                                        token.Code = 20;
                                        token.Value += source[i];
                                        list.Add(token);
                                        i++;
                                        break;
                                    case '=':   // 19 |=
                                        token.Code = 19;
                                        token.Value += source[i];
                                        list.Add(token);
                                        i++;
                                        break;
                                    default:    // 18 |
                                        token.Code = 18;
                                        list.Add(token);
                                        break;
                                }
                                break;

                            case '!':   //21-22
                                token.Value = source[i] + "";
                                i++;
                                if (source[i] == '=')   // 22 !=
                                {
                                    token.Code = 22;
                                    token.Value += source[i];
                                    list.Add(token);
                                    i++;
                                }
                                else
                                {// 21 !
                                    token.Code = 21;
                                    list.Add(token);
                                }
                                break;

                            case '^':   //23-24
                                token.Value = source[i] + "";
                                i++;
                                if (source[i] == '=')   // 24 ^=
                                {
                                    token.Code = 24;
                                    token.Value += source[i];
                                    list.Add(token);
                                    i++;
                                }
                                else
                                {// 23 ^
                                    token.Code = 23;
                                    list.Add(token);
                                }
                                break;

                            case '<':   //25-28 < <= << <<=
                                token.Value = source[i] + "";
                                i++;
                                if (source[i] == '<')
                                {
                                    token.Value += source[i];
                                    i++;
                                    if (source[i] == '=')   // 28 <<=
                                    {
                                        token.Value += source[i];
                                        token.Code = 28;
                                        list.Add(token);
                                        i++;
                                    }
                                    else
                                    {// 27 <<
                                        token.Code = 27;
                                        list.Add(token);
                                    }
                                }
                                else if (source[i] == '=') //26 <=
                                {
                                    token.Value += source[i];
                                    token.Code = 26;
                                    list.Add(token);
                                    i++;
                                }
                                else
                                {// 25 <
                                    token.Code = 25;
                                    list.Add(token);
                                }
                                break;

                            case '>':   //29-32
                                token.Value = source[i] + "";
                                i++;
                                if (source[i] == '>')
                                {
                                    token.Value += source[i];
                                    i++;
                                    if (source[i] == '=')   // 32 >>=
                                    {
                                        token.Value += source[i];
                                        token.Code = 32;
                                        list.Add(token);
                                        i++;
                                    }
                                    else
                                    {// 31 >>
                                        token.Code = 31;
                                        list.Add(token);
                                    }
                                }
                                else if (source[i] == '=') //30 >=
                                {
                                    token.Value += source[i];
                                    token.Code = 30;
                                    list.Add(token);
                                    i++;
                                }
                                else
                                {// 29 >
                                    token.Code = 29;
                                    list.Add(token);
                                }
                                break;

                            case '=':   //33-34
                                token.Value = source[i] + "";
                                i++;
                                if (source[i] == '=')   // 34 ==
                                {
                                    token.Code = 34;
                                    token.Value += source[i];
                                    list.Add(token);
                                    i++;
                                }
                                else
                                {// 33 =
                                    token.Code = 33;
                                    list.Add(token);
                                }
                                break;
                            default:
                                break;
                        }
                    }

                    //是否为界限符（35-46）
                    else if (_bound.Contains(source[i]))
                    {
                        Token token = new Token();
                        for (int j = 0; j < _bound.Length; j++)
                        {
                            if (_bound[j] == source[i])
                            {
                                token.Code = 35 + j;
                                token.Value = source[i] + "";
                                list.Add(token);
                                i++;
                                break;
                            }
                        }
                    }

                    //是否为常量（48-49）/整型、实型
                    else if (char.IsDigit(source[i]))
                    {
                        Token token = new Token();
                        token.Value = source[i] + "";
                        i++;
                        while (char.IsDigit(source[i]) | source[i] == '.')
                        {
                            token.Value += source[i];
                            i++;
                        }
                        int count_point = 0;
                        //统计小数点个数
                        for (int j = 0; j < token.Value.Length; j++)
                        {
                            if (token.Value[j] == '.')
                                count_point++;
                        }
                        if (count_point == 0)
                        {
                            // token.Value = "整型";
                            token.Code = 48;
                            list.Add(token);
                        }
                        else if (count_point == 1)
                        {
                            //token.Value = "实型";
                            token.Code = 49;
                            list.Add(token);
                        }
                        else
                        {
                            token.Code = -1;
                            list.Add(token);
                            errors += "error in position " + (i-1) + ", 行数: " + lines + ". 连续小数点\r\n";
                            error_position.Add(i-1);
                        }
                    }

                    //字母或下划线开头
                    else if (source[i] == '_' || char.IsLetter(source[i]))
                    {
                        Token token = new Token();
                        token.Value = source[i] + "";
                        i++;
                        while (source[i] == '_' || char.IsDigit(source[i]) || char.IsLetter(source[i]))
                        {
                            token.Value += source[i];
                            i++;
                        }
                        //是否为关键字（50-99）
                        if (_keyword.Contains(token.Value))
                            for (int j = 0; j < _keyword.Length; j++)
                            {
                                if (token.Value.Equals(_keyword[j]))
                                {
                                    token.Code = 50 + j;
                                    list.Add(token);
                                    break;
                                }
                            }

                        //是否为标识符 100
                        else
                        {
                            token.Code = 100;
                            //token.Value = "标识符";
                            list.Add(token);
                        }
                    }

                    //跳过无意义字符
                    else if (source[i] == ' ' || source[i] == '\n' || source[i] == '\t' || source[i] == '\r' || source[i] == ':')
                    {
                        if (source[i] == '\n')
                            lines++;
                        i++;
                    }

                    //错误码  -1
                    else
                    {
                        Token token = new Token();
                        token.Code = -1;
                        token.Value = source[i] + "";
                        list.Add(token);
                        errors += "error in position " + i + ", lines:" + lines + ". 无法识别\r\n";
                        error_position.Add(i-1);
                        i++;
                    }
                }
            }
            catch (Exception)
            {
                errors+="error in position "+(i-1)+", lines:"+lines+". "+source[i-1]+"处非法终止，建议加上界符结束\r\n";
                error_position.Add(i-1);
            }
            return list;
        }

        //返回错误信息
        public static string error()
        {
            return errors;
        }

        //返回错误位置集合
        public static List<int> errorsPosition()
        {
            return error_position;
        }
    }
}
