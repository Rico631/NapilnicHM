using Second.Models;

namespace Second.Interfaces
{
    public interface IWarehouseService
    {
        Stock CreateStock(Stock stock);
        Stock GetStockByProduct(Product product);
        ReserveStock ReserveStock(ReserveStock reserveStock);
        void UpdateReservingQuantity(int reserveStockID, int quantity);
    }
}