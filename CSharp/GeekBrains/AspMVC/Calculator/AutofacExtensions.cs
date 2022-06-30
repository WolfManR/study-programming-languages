using Autofac;

using Calculator.CalculatorOperations;

namespace Calculator;

static class AutofacExtensions
{
    public static ContainerBuilder AddOperation(this ContainerBuilder self, string name, string description, Operation<double> operation)
    {
        OperationMetadata metadata = new()
        {
            Name = name,
            Description = description,
            Operation = operation
        };
        self.RegisterInstance(metadata);
        return self;
    }
}