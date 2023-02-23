create table products (
  id bigint primary key,
  name varchar(255) not null
);

create table categories (
  id bigint primary key,
  name varchar(255) not null
);

create table category_product (
  product_id bigint,
  category_id bigint,
  constraint fk_category_product_product_id foreign key (product_id) references products (id),
  constraint fk_category_product_category_id foreign key (category_id) references categories (id)
);

insert into products
values (1, 'Product1'),
       (2, 'Product2'),
       (3, 'Product3'),
       (4, 'Product4'),
       (5, 'Product5'),
       (6, 'Product6');

insert into categories
values (1, 'Category1'),
       (2, 'Category2'),
       (3, 'Category3'),
       (4, 'Category4');

insert into category_product
values (1, 1),
       (1, 2),
       (2, 2),
       (3, 3),
       (4, 1),
       (4, 2),
       (4, 3),
       (5, 1);

