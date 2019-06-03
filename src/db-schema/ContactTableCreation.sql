-- Table: public.contact

-- DROP TABLE public.contact;

CREATE TABLE public.contacts
(
    id SERIAL PRIMARY KEY,
    firstname text COLLATE pg_catalog."default",
    middlename text COLLATE pg_catalog."default",
    lastname text COLLATE pg_catalog."default",
    phonenumber text COLLATE pg_catalog."default",
    jobtitle text COLLATE pg_catalog."default",
    secondaryphonenumber text COLLATE pg_catalog."default",
    userid integer NOT NULL,
    deleted bit(1) NOT NULL DEFAULT 0::bit,
    CONSTRAINT userid_user_id FOREIGN KEY (userid)
        REFERENCES public.users (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;

