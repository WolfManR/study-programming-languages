namespace Calculator.CalculatorOperations;

static class Operations
{
    public static double Sum(OperationFormModel<double> formModel)
    {
        return formModel.LeftOperand + formModel.RightOperand;
    }

    public static double Subtract(OperationFormModel<double> formModel)
    {
        return formModel.LeftOperand - formModel.RightOperand;
    }

    public static double Multiply(OperationFormModel<double> formModel)
    {
        return formModel.LeftOperand * formModel.RightOperand;
    }

    public static double Division(OperationFormModel<double> formModel)
    {
        return formModel.LeftOperand / formModel.RightOperand;
    }
}