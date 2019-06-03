-- Table: public.company

-- DROP TABLE public.company;

CREATE TABLE public.company
(
    id integer NOT NULL DEFAULT nextval('company_id_seq'::regclass),
    companynumber text COLLATE pg_catalog."default" NOT NULL,
    companyname text COLLATE pg_catalog."default" NOT NULL,
    companytype integer NOT NULL,
    companyfunction integer NOT NULL,
    primaryaddressid integer NOT NULL,
    primarycontactid integer NOT NULL,
    CONSTRAINT company_pkey PRIMARY KEY (id),
    CONSTRAINT "primaryaddressid-address-id" FOREIGN KEY (primaryaddressid)
        REFERENCES public.address (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "primarycontactid-contact-id" FOREIGN KEY (primarycontactid)
        REFERENCES public.contacts (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;
