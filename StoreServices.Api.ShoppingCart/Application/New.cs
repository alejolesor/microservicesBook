using MediatR;
using StoreServices.Api.ShoppingCart.Model;
using StoreServices.Api.ShoppingCart.Persitence;

namespace StoreServices.Api.ShoppingCart.Application
{
    public class New
    {
        public class Execute : IRequest
        {
            public DateTime? CreationDateSession { get; set; }
            public List<string> ProductList { get; set; }
        }
        public class Managment : IRequestHandler<Execute>
        {
            private readonly CartContext _cartContext;
            public Managment(CartContext cartContext)
            {
                _cartContext = cartContext;
            }
            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var cartSession = new CartSession
                {
                    CreationDate = request.CreationDateSession
                };
                _cartContext.CartSession.Add(cartSession);
                var value = await _cartContext.SaveChangesAsync();
                if (value == 0) { throw new Exception("error in the session insert "); }
                int id = cartSession.CartSessionId;
                foreach (var item in request.ProductList)
                {
                    var detailSession = new CartSessionDetail
                    {
                        CreationDate = DateTime.Now,
                        CartSessionId = id,
                        ProductSelected = item
                    };
                    _cartContext.CartSessonDetail.Add(detailSession);
                }

                value = await _cartContext.SaveChangesAsync();
                if (value > 0) { return Unit.Value; }
                throw new Exception("could not insert CartSessionDetail ");
            }
        }
    }
}
