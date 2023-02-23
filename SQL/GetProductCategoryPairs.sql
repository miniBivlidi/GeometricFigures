SELECT 
	p.name as "Product Name",
	c.name as "Category Name"
FROM category_product cp
RIGHT JOIN products p
		ON cp.product_id = p.id
LEFT JOIN categories c 
		ON cp.category_id = c.id