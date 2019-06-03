CREATE TABLE public.users
(
    id SERIAL PRIMARY KEY,
    username text COLLATE pg_catalog."default",
    password text COLLATE pg_catalog."default"
)
WITH (
    OIDS = FALSE
)
TABLESPACE pg_default;


	