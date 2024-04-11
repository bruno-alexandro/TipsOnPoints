public interface ICardRepository {
    void Add(Card card);
    List<Card> Get();
}