using System.ComponentModel.DataAnnotations;

namespace Calculator.CalculatorOperations;

class OperationFormModel<T>
{
    [Display(Prompt = "Input left operand")]
    public T LeftOperand { get; set; }

    [Display(Prompt = "Input right operand")]
    public T RightOperand { get; set; }
}