using FluentValidation;
using Ambev.DeveloperEvaluation.Application.Sales.Commands;

namespace Ambev.DeveloperEvaluation.Application.Sales.Validators
{
    public class CreateSaleValidator : AbstractValidator<CreateSaleCommand>
    {
        public CreateSaleValidator()
        {
            RuleFor(x => x.CustomerName)
                .NotEmpty()
                .WithMessage("Nome do cliente é obrigatório")
                .MaximumLength(100);

            RuleFor(x => x.BranchName)
                .NotEmpty()
                .WithMessage("Nome da filial é obrigatório");

            RuleFor(x => x.Items)
                .NotEmpty()
                .WithMessage("A venda deve ter pelo menos um item");

            RuleForEach(x => x.Items).ChildRules(item =>
            {
                item.RuleFor(x => x.ProductName)
                    .NotEmpty()
                    .WithMessage("Nome do produto é obrigatório");

                item.RuleFor(x => x.Quantity)
                    .GreaterThan(0)
                    .LessThanOrEqualTo(20)
                    .WithMessage("Quantidade deve ser entre 1 e 20");

                item.RuleFor(x => x.UnitPrice)
                    .GreaterThan(0)
                    .WithMessage("Preço unitário deve ser maior que zero");
            });
        }
    }
}
