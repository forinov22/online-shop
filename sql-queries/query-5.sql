-- Get all completed orders with a given product. Order from newest to latest
SELECT o.o_id, o.o_created_at
FROM "Orders" o
JOIN "OrderItems" oi ON o.o_id = oi.oi_order_id
WHERE oi.oi_product_version_id = 1
  AND o.o_order_status = 'completed'
ORDER BY o.o_created_at DESC;
