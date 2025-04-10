namespace PortfolioV2.Application.Commons.IResponses.BaseHandlers;

public interface IResponseMapper<TSource,TResponse> where TResponse : new()
{
    TResponse Map(TSource source);
}




//IResponseMapper<TSource, TResponse> genel(generic) bir arayüzdür.
//TSource, eşlenecek kaynak tipini temsil eder (örneğimizde CreateHeroDto).
//TResponse, eşlemenin sonucu olan hedef tipi temsil eder (örneğimizde CreateHeroResponseDto).
//Map(TSource source) metodu, kaynak nesneyi alıp hedef nesneye dönüştürmek için tanımlanmıştır.