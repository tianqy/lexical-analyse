using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace word_analyse
{
    class Token
    {
        private int _code=-1;
        private string _value="";

        public Token(int _code=-1, string _value="")     //构造方法
        {
            this._code = _code;
            this._value = _value;
        }

        public int Code     //Code属性
        {
            get { return _code; }
            set { _code = value; }
        }
        
        public string Value     //Value属性
        {
            get { return _value; }
            set { _value = value; }
        }


    }
}
