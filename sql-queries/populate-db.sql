-- Insert test data for the Users table
INSERT INTO  public."Addresses" ("Id", "AddressString", "UserId")
VALUES
(1, 'Grushevskaya 90-19', 1),
(2, 'Yanki Brylia 21-139', 2),
(3, 'Papanina 18-35', 3);

INSERT INTO public."Users" ("Id", "Email", "Phone", "FirstName", "LastName", "Password", "UserType")
VALUES
(1, 'user1@example.com', '1234567890', 'John', 'Doe', 'password123', 1),
(2, 'user2@example.com', '9876543210', 'Jane', 'Smith', 'password456', 2),
(3, 'user3@example.com', '5555555555', 'Alice', 'Johnson', 'password789', 2);

-- Insert test data for the Brands table
INSERT INTO public."Brands" ("Name")
VALUES
('Brand X'),
('Brand Y'),
('Brand Z');

-- Insert test data for the Sections table
INSERT INTO public."Sections" ("Name")
VALUES
('Section 1'),
('Section 2');

-- Insert top-level categories with NULL parent IDs
INSERT INTO public."Categories" ("Name", "ParentCategoryId")
VALUES ('Category A', NULL), ('Category B', NULL);

-- Insert subcategories with valid parent category IDs
INSERT INTO public."Categories" ("Name", "ParentCategoryId")
VALUES ('Subcategory 1', 1), ('Subcategory 2', 2);



-- Insert test data for the Products table
INSERT INTO public."Products" ("Name", "Price", "BrandId", "CategoryId", "AverageRating")
VALUES
('Product A', 19.99, 1, 1, 4.5),
('Product B', 29.99, 2, 2, 3.8),
('Product C', 39.99, 3, 2, 4.0);

-- Insert test data for the Reviews table
INSERT INTO public."Reviews" ("Rating", "Comment", "ProductId", "UserId", "Title", "CreatedAt")
VALUES
(4.5, 'Great product!', 1, 1, 'Positive Review', '2023-10-01'),
(3.8, 'Good but could be better.', 2, 2, 'Mixed Review', '2023-10-02');

-- Add more test data for other tables as needed

