using ComplexAlgebra;

namespace Calculus
{
    /// <summary>
    /// A calculator for <see cref="Complex"/> numbers, supporting 2 operations ('+', '-').
    /// The calculator visualizes a single value at a time.
    /// Users may change the currently shown value as many times as they like.
    /// Whenever an operation button is chosen, the calculator memorises the currently shown value and resets it.
    /// Before resetting, it performs any pending operation.
    /// Whenever the final result is requested, all pending operations are performed and the final result is shown.
    /// The calculator also supports resetting.
    /// </summary>
    ///
    /// HINT: model operations as constants
    /// HINT: model the following _public_ properties methods
    /// HINT: - a property/method for the currently shown value
    /// HINT: - a property/method to let the user request the final result
    /// HINT: - a property/method to let the user reset the calculator
    /// HINT: - a property/method to let the user request an operation
    /// HINT: - the usual ToString() method, which is helpful for debugging
    /// HINT: - you may exploit as many _private_ fields/methods/properties as you like
    ///
    /// TODO: implement the calculator class in such a way that the Program below works as expected
    class Calculator
    {
        public const char OperationPlus = '+';
        public const char OperationMinus = '-';
        private char? _currentOperation;
        private Complex _tmpResult;
        
        // TODO fill this class

        public Calculator()
        {
            Value = null;
        }

        public Complex Value { set; get; }

        public char? Operation 
        {
            get => _currentOperation;
            set
            {
                if (_tmpResult != null) 
                {
                    ComputeResult();
                }
                _currentOperation = value;
                _tmpResult = Value;
                Value = null;
            }
        }
         
        public void ComputeResult() 
        {
            bool computing = (_currentOperation != null);
            if (computing)
            {
                switch (_currentOperation) 
                {
                    case OperationPlus:
                    Value = _tmpResult.Sum(Value);
                    break;

                    case OperationMinus:
                    Value = _tmpResult.Sub(Value);
                    break;
                }
                _currentOperation = null;
            } 
            else 
            {
                _tmpResult = null;
            }
        }

        public override string ToString() 
        {
            if (Value == null  && _currentOperation == null)
            {
                return "null, null";
            }
            else if (Value == null && _currentOperation != null)
            {
                return $"null, {_currentOperation}";
            }
            else if (Value != null && _currentOperation == null)
            {
                return $"{Value}, null";
            }
            else
            {
                return $"{Value}, {_currentOperation}"; 
            }
        }

        public void Reset()
        {
            Value = null;
            _currentOperation = null;
            _tmpResult = null;
        }
    }
}