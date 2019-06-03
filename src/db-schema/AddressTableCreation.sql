-- Table: public.addresses

-- DROP TABLE public.addresses;

CREATE TABLE public.address
(
    id integer NOT NULL DEFAULT nextval('addresses_id_seq'::regclass),
    addressline1 text COLLATE pg_catalog."default" NOT NULL,
    addressline2 text COLLATE pg_catalog."default",
    city text COLLATE pg_catalog."default" NOT NULL,
    country text COLLATE pg_catalog."default" NOT NULL,
    county text COLLATE pg_catalog."default" NOT NULL,
    postcode text COLLATE pg_catalog."default" NOT NULL,
    userid integer NOT NULL,
    CONSTRAINT addresses_pkey PRIMARY KEY (id),
    CONSTRAINT userid_user_id FOREIGN KEY (userid)
        REFERENCES public.users (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;
