SELECT Products.ProductName, Categories.CategoryName FROM Products
LEFT JOIN ProductsCategories ON Products.ProductId= ProductsCategories.ProductId
LEFT JOIN Categories ON Category.CategoryId=ProductsCategories.PositionId
ORDER BY ProductName