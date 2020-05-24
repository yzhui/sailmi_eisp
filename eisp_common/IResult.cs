using System;
using System.Collections.Generic;
namespace Eisp.Common
{
    public interface IResult<T>
    {
        bool HasError { get; set;}
        string ErrorMessage { get; set;}
        string Message { get; set;}
        T Result { get; set;}
        List<T> ResultList { get; set;}
    }

    public class IntResult : IResult<int>
    {
        private bool _hasError = false;
        public bool HasError
        {
            get { return _hasError; }
            set { _hasError = value; }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public int _result;
        public int Result
        {
            get { return _result; }
            set { _result = value; }
        }

        private List<int> _resultList;
        public List<int> ResultList
        {
            get { return _resultList; }
            set { _resultList = value; }
        }
    }

    public class BooleanResult : IResult<bool>
    {
        private bool _hasError = false;
        public bool HasError
        {
            get { return _hasError; }
            set { _hasError = value; }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public bool _result;
        public bool Result
        {
            get { return _result; }
            set { _result = value; }
        }

        private List<bool> _resultList;
        public List<bool> ResultList
        {
            get { return _resultList; }
            set { _resultList = value; }
        }
    }

    public class ByteResult : IResult<byte>
    {
        private bool _hasError = false;
        public bool HasError
        {
            get { return _hasError; }
            set { _hasError = value; }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public byte _result;
        public byte Result
        {
            get { return _result; }
            set { _result = value; }
        }

        private List<byte> _resultList;
        public List<byte> ResultList
        {
            get { return _resultList; }
            set { _resultList = value; }
        }
    }

    public class StringResult : IResult<string>
    {
        private bool _hasError = false;
        public bool HasError
        {
            get { return _hasError; }
            set { _hasError = value; }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public string _result;
        public string Result
        {
            get { return _result; }
            set { _result = value; }
        }

        private List<string> _resultList;
        public List<string> ResultList
        {
            get { return _resultList; }
            set { _resultList = value; }
        }
    }
}
