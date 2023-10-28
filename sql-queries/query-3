-- Select all brands with the number of their products respectively. Order by the number of products.
SELECT b.b_name AS brand_name, COUNT(p.p_id) AS product_count
FROM "Brands" b
JOIN "Products" p ON b.b_id = p.p_brand_id
GROUP BY b.b_name
ORDER BY product_count DESC;