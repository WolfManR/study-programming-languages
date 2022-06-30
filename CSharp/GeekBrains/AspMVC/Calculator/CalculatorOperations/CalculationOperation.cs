namespace Calculator.CalculatorOperations;

record CalculationOperation(OperationFormModel<double> Form, Operation<double> Operation)
{
    public double Calculate() => Operation.Invoke(Form);
};