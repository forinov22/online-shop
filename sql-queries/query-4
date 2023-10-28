-- Get all products for a given category and section
SELECT p.*
FROM "Products" p
JOIN "SectionCategory" sc ON p.p_category_id = sc.sc_category_id
JOIN "Sections" s ON sc.sc_section_id = s.s_id
JOIN "Categories" c ON sc.sc_category_id = c.c_id
WHERE s.s_name = 'SectionName'
  AND c.c_name = 'CategoryName';
