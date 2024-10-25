using FluentValidation;
using Orders.Comunication.Request;

namespace Orders.Application.UseCases.AddNewOrder
{
    public class NewOrderValidation : AbstractValidator<RequestOrderJson>
    {
        public NewOrderValidation() 
        {
            RuleFor(order => order.Itens).NotEmpty().WithMessage("Pelo menos um item deve ser adicionado.");
            RuleForEach(order => order.Itens).ChildRules(item =>
            {
                item.RuleFor(i => i.Quantidade).GreaterThan(0).WithMessage("Quantidade não pode ser menor que 1.");

                item.RuleFor(i => i.Name).NotEmpty().WithMessage("O Nome do item não pode ser vazio.")
                                         .MaximumLength(40).WithMessage("O Nome não pode ser maior que 40 caracteres.");
            });
        }
    }
}
