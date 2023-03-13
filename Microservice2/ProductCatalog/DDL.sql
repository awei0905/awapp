-- DROP SCHEMA public;

CREATE SCHEMA public AUTHORIZATION usr;

-- DROP SEQUENCE public.newtable_id_seq;

CREATE SEQUENCE public.newtable_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE public.productcatalogtype_id_seq;

CREATE SEQUENCE public.productcatalogtype_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE public.productitemtype_productitemtypeid_seq;

CREATE SEQUENCE public.productitemtype_productitemtypeid_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;-- public."ProductItem" definition

-- Drop table

-- DROP TABLE "ProductItem";

CREATE TABLE "ProductItem" (
	"ProductItemId" int4 NOT NULL DEFAULT nextval('newtable_id_seq'::regclass),
	"Name" varchar(100) NOT NULL,
	"Description" varchar(100) NOT NULL,
	"Price" numeric NOT NULL,
	"Quantity" int4 NOT NULL DEFAULT 0,
	"ImageUrl" varchar(1024) NOT NULL DEFAULT ''::character varying,
	CONSTRAINT productitem_pk PRIMARY KEY ("ProductItemId")
);


-- public."ProductType" definition

-- Drop table

-- DROP TABLE "ProductType";

CREATE TABLE "ProductType" (
	"ProductTypeId" int4 NOT NULL DEFAULT nextval('productcatalogtype_id_seq'::regclass),
	"Name" varchar(100) NOT NULL,
	CONSTRAINT productcatalogtype_pk PRIMARY KEY ("ProductTypeId")
);


-- public."ProductItemType" definition

-- Drop table

-- DROP TABLE "ProductItemType";

CREATE TABLE "ProductItemType" (
	"ProductItemTypeId" int4 NOT NULL DEFAULT nextval('productitemtype_productitemtypeid_seq'::regclass),
	"ProductItemId" int4 NOT NULL,
	"ProductTypeId" int4 NOT NULL,
	CONSTRAINT productitemtype_pk PRIMARY KEY ("ProductItemTypeId"),
	CONSTRAINT productitemtype_fk FOREIGN KEY ("ProductItemId") REFERENCES "ProductItem"("ProductItemId"),
	CONSTRAINT productitemtype_fk_1 FOREIGN KEY ("ProductTypeId") REFERENCES "ProductType"("ProductTypeId")
);
CREATE UNIQUE INDEX productitemtype_productid_idx ON public."ProductItemType" USING btree ("ProductItemId", "ProductTypeId");
