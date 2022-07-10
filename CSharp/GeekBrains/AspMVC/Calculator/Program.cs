using Autofac;

using Calculator;
using Calculator.CalculatorOperations;

var builder = new ContainerBuilder();
builder.RegisterType<CalculationProcessor>();
builder.AddOperation("Sum", "Summation of two operands", Operations.Sum);
builder.AddOperation("Sub", "Subtraction of two operands", Operations.Subtract);
builder.AddOperation("Mult", "Multiply two operands", Operations.Multiply);
builder.AddOperation("Div", "Division of two operands", Operations.Division);
var container = builder.Build();

//===================================================

container.Resolve<CalculationProcessor>().Start();