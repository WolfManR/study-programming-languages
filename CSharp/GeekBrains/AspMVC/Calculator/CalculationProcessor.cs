using Calculator.CalculatorOperations;

using Sharprompt;

namespace Calculator;

class CalculationProcessor
{
    private readonly IEnumerable<OperationMetadata> _operations;

    public CalculationProcessor(IEnumerable<OperationMetadata> operations) => _operations = operations;

    public void Start()
    {
        double? previousResult = null;
        do
        {
            do
            {
                var operation = SelectOperation(previousResult);
                previousResult = operation.Calculate();
                Console.WriteLine($"Result of operation is {previousResult}");
            } while (Prompt.Confirm("Continue calculation with previous result?"));
        } while (!Prompt.Confirm("You wanna exit?"));
    }

    private CalculationOperation SelectOperation(double? previousResult = null)
    {
        OperationFormModel<double> form;
        if (previousResult is null)
        {
            form = Prompt.AutoForms<OperationFormModel<double>>();
        }
        else
        {
            var rightOperand = Prompt.Input<double>("Input right operand");
            form = new OperationFormModel<double>() { LeftOperand = previousResult.Value, RightOperand = rightOperand };
        }

        var operation = Prompt.Select("Select operation", _operations);
        return new(form, operation.Operation);
    }
}