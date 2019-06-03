--
-- PostgreSQL database dump
--

-- Dumped from database version 11.2 (Debian 11.2-1.pgdg90+1)
-- Dumped by pg_dump version 11.2

-- Started on 2019-06-03 21:28:59

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 196 (class 1259 OID 17252)
-- Name: notificationtype; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.notificationtype (
    id integer NOT NULL,
    name text NOT NULL
);


ALTER TABLE public.notificationtype OWNER TO postgres;

--
-- TOC entry 197 (class 1259 OID 17258)
-- Name: ProductUpdateType_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."ProductUpdateType_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."ProductUpdateType_id_seq" OWNER TO postgres;

--
-- TOC entry 3000 (class 0 OID 0)
-- Dependencies: 197
-- Name: ProductUpdateType_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."ProductUpdateType_id_seq" OWNED BY public.notificationtype.id;


--
-- TOC entry 198 (class 1259 OID 17260)
-- Name: address; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.address (
    id integer NOT NULL,
    addressline1 text NOT NULL,
    addressline2 text,
    city text NOT NULL,
    country text NOT NULL,
    county text NOT NULL,
    postcode text NOT NULL,
    userid uuid NOT NULL,
    companyid integer NOT NULL
);


ALTER TABLE public.address OWNER TO postgres;

--
-- TOC entry 199 (class 1259 OID 17266)
-- Name: address_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.address_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.address_id_seq OWNER TO postgres;

--
-- TOC entry 3003 (class 0 OID 0)
-- Dependencies: 199
-- Name: address_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.address_id_seq OWNED BY public.address.id;


--
-- TOC entry 200 (class 1259 OID 17268)
-- Name: bid; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.bid (
    id integer NOT NULL,
    productid integer NOT NULL,
    price real NOT NULL,
    companyid integer NOT NULL,
    userid uuid NOT NULL,
    cancelled boolean DEFAULT false NOT NULL,
    accepted boolean DEFAULT false NOT NULL,
    declined boolean DEFAULT false NOT NULL
);


ALTER TABLE public.bid OWNER TO postgres;

--
-- TOC entry 201 (class 1259 OID 17274)
-- Name: bid_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.bid_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.bid_id_seq OWNER TO postgres;

--
-- TOC entry 3006 (class 0 OID 0)
-- Dependencies: 201
-- Name: bid_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.bid_id_seq OWNED BY public.bid.id;


--
-- TOC entry 202 (class 1259 OID 17276)
-- Name: company; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.company (
    id integer NOT NULL,
    companynumber integer NOT NULL,
    companytypeid integer NOT NULL,
    companyfunctionid integer NOT NULL,
    logourl text,
    companyname text NOT NULL
);


ALTER TABLE public.company OWNER TO postgres;

--
-- TOC entry 203 (class 1259 OID 17282)
-- Name: company_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.company_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.company_id_seq OWNER TO postgres;

--
-- TOC entry 3009 (class 0 OID 0)
-- Dependencies: 203
-- Name: company_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.company_id_seq OWNED BY public.company.id;


--
-- TOC entry 204 (class 1259 OID 17289)
-- Name: companyfunction; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.companyfunction (
    id integer NOT NULL,
    name text NOT NULL
);


ALTER TABLE public.companyfunction OWNER TO postgres;

--
-- TOC entry 205 (class 1259 OID 17295)
-- Name: companyfunction_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.companyfunction_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.companyfunction_id_seq OWNER TO postgres;

--
-- TOC entry 3012 (class 0 OID 0)
-- Dependencies: 205
-- Name: companyfunction_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.companyfunction_id_seq OWNED BY public.companyfunction.id;


--
-- TOC entry 206 (class 1259 OID 17297)
-- Name: companytype; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.companytype (
    id integer NOT NULL,
    name text NOT NULL
);


ALTER TABLE public.companytype OWNER TO postgres;

--
-- TOC entry 207 (class 1259 OID 17303)
-- Name: companytype_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.companytype_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.companytype_id_seq OWNER TO postgres;

--
-- TOC entry 3015 (class 0 OID 0)
-- Dependencies: 207
-- Name: companytype_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.companytype_id_seq OWNED BY public.companytype.id;


--
-- TOC entry 208 (class 1259 OID 17305)
-- Name: contact; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.contact (
    id integer NOT NULL,
    firstname text NOT NULL,
    middlename text,
    lastname text NOT NULL,
    jobtitle text NOT NULL,
    phonenumber text NOT NULL,
    secondaryphonenumber text,
    userid uuid NOT NULL,
    companyid integer NOT NULL
);


ALTER TABLE public.contact OWNER TO postgres;

--
-- TOC entry 209 (class 1259 OID 17311)
-- Name: contact_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.contact_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.contact_id_seq OWNER TO postgres;

--
-- TOC entry 3018 (class 0 OID 0)
-- Dependencies: 209
-- Name: contact_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.contact_id_seq OWNED BY public.contact.id;


--
-- TOC entry 210 (class 1259 OID 17313)
-- Name: notification; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.notification (
    id integer NOT NULL,
    read boolean DEFAULT false NOT NULL,
    productupdatetypeid integer NOT NULL,
    duedate timestamp with time zone NOT NULL,
    information text NOT NULL,
    datecreated timestamp with time zone DEFAULT now() NOT NULL,
    receivinguserid uuid NOT NULL
);


ALTER TABLE public.notification OWNER TO postgres;

--
-- TOC entry 211 (class 1259 OID 17330)
-- Name: product; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.product (
    id integer NOT NULL,
    reference integer NOT NULL,
    title text NOT NULL,
    description text NOT NULL,
    companyid integer NOT NULL,
    userid uuid NOT NULL,
    cost integer NOT NULL,
    datecreated timestamp with time zone DEFAULT now() NOT NULL,
    enddate timestamp with time zone NOT NULL,
    cancelled boolean DEFAULT false NOT NULL
);


ALTER TABLE public.product OWNER TO postgres;

--
-- TOC entry 212 (class 1259 OID 17338)
-- Name: product_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.product_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.product_id_seq OWNER TO postgres;

--
-- TOC entry 3022 (class 0 OID 0)
-- Dependencies: 212
-- Name: product_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.product_id_seq OWNED BY public.product.id;


--
-- TOC entry 213 (class 1259 OID 17340)
-- Name: product_reference_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.product_reference_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.product_reference_seq OWNER TO postgres;

--
-- TOC entry 3024 (class 0 OID 0)
-- Dependencies: 213
-- Name: product_reference_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.product_reference_seq OWNED BY public.product.reference;


--
-- TOC entry 214 (class 1259 OID 17347)
-- Name: productupdate_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.productupdate_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.productupdate_id_seq OWNER TO postgres;

--
-- TOC entry 3026 (class 0 OID 0)
-- Dependencies: 214
-- Name: productupdate_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.productupdate_id_seq OWNED BY public.notification.id;


--
-- TOC entry 215 (class 1259 OID 17349)
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    id uuid NOT NULL,
    username text NOT NULL,
    password text NOT NULL,
    companyid integer NOT NULL
);


ALTER TABLE public.users OWNER TO postgres;

--
-- TOC entry 2804 (class 2604 OID 17355)
-- Name: address id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.address ALTER COLUMN id SET DEFAULT nextval('public.address_id_seq'::regclass);


--
-- TOC entry 2808 (class 2604 OID 17356)
-- Name: bid id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.bid ALTER COLUMN id SET DEFAULT nextval('public.bid_id_seq'::regclass);


--
-- TOC entry 2809 (class 2604 OID 17357)
-- Name: company id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.company ALTER COLUMN id SET DEFAULT nextval('public.company_id_seq'::regclass);


--
-- TOC entry 2810 (class 2604 OID 17359)
-- Name: companyfunction id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.companyfunction ALTER COLUMN id SET DEFAULT nextval('public.companyfunction_id_seq'::regclass);


--
-- TOC entry 2811 (class 2604 OID 17360)
-- Name: companytype id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.companytype ALTER COLUMN id SET DEFAULT nextval('public.companytype_id_seq'::regclass);


--
-- TOC entry 2812 (class 2604 OID 17361)
-- Name: contact id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.contact ALTER COLUMN id SET DEFAULT nextval('public.contact_id_seq'::regclass);


--
-- TOC entry 2815 (class 2604 OID 17362)
-- Name: notification id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.notification ALTER COLUMN id SET DEFAULT nextval('public.productupdate_id_seq'::regclass);


--
-- TOC entry 2803 (class 2604 OID 17363)
-- Name: notificationtype id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.notificationtype ALTER COLUMN id SET DEFAULT nextval('public."ProductUpdateType_id_seq"'::regclass);


--
-- TOC entry 2818 (class 2604 OID 17365)
-- Name: product id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product ALTER COLUMN id SET DEFAULT nextval('public.product_id_seq'::regclass);


--
-- TOC entry 2819 (class 2604 OID 17366)
-- Name: product reference; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product ALTER COLUMN reference SET DEFAULT nextval('public.product_reference_seq'::regclass);

--
-- TOC entry 2982 (class 0 OID 17289)
-- Dependencies: 204
-- Data for Name: companyfunction; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.companyfunction (id, name) FROM stdin;
3	Other
1	Seller\n
2	Buyer
\.


--
-- TOC entry 2984 (class 0 OID 17297)
-- Dependencies: 206
-- Data for Name: companytype; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.companytype (id, name) FROM stdin;
1	LTD
2	PLC
3	Solo
\.


--
-- TOC entry 2986 (class 0 OID 17305)
-- Dependencies: 208
-- Data for Name: contact; Type: TABLE DATA; Schema: public; Owner: postgres
--




--
-- TOC entry 2974 (class 0 OID 17252)
-- Dependencies: 196
-- Data for Name: notificationtype; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.notificationtype (id, name) FROM stdin;
1	Bid
2	Product created
\.


--
-- TOC entry 3029 (class 0 OID 0)
-- Dependencies: 197
-- Name: ProductUpdateType_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."ProductUpdateType_id_seq"', 2, true);


--
-- TOC entry 3030 (class 0 OID 0)
-- Dependencies: 199
-- Name: address_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.address_id_seq', 3, true);


--
-- TOC entry 3031 (class 0 OID 0)
-- Dependencies: 201
-- Name: bid_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.bid_id_seq', 11, true);


--
-- TOC entry 3032 (class 0 OID 0)
-- Dependencies: 203
-- Name: company_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.company_id_seq', 8, true);


--
-- TOC entry 3033 (class 0 OID 0)
-- Dependencies: 205
-- Name: companyfunction_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.companyfunction_id_seq', 3, true);


--
-- TOC entry 3034 (class 0 OID 0)
-- Dependencies: 207
-- Name: companytype_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.companytype_id_seq', 3, true);


--
-- TOC entry 3035 (class 0 OID 0)
-- Dependencies: 209
-- Name: contact_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.contact_id_seq', 3, true);


--
-- TOC entry 3036 (class 0 OID 0)
-- Dependencies: 212
-- Name: product_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.product_id_seq', 11, true);


--
-- TOC entry 3037 (class 0 OID 0)
-- Dependencies: 213
-- Name: product_reference_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.product_reference_seq', 11, true);


--
-- TOC entry 3038 (class 0 OID 0)
-- Dependencies: 214
-- Name: productupdate_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.productupdate_id_seq', 21, true);


--
-- TOC entry 2823 (class 2606 OID 17371)
-- Name: address address_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.address
    ADD CONSTRAINT address_pkey PRIMARY KEY (id);


--
-- TOC entry 2825 (class 2606 OID 17373)
-- Name: bid bid_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.bid
    ADD CONSTRAINT bid_pkey PRIMARY KEY (id);


--
-- TOC entry 2827 (class 2606 OID 17375)
-- Name: company company_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.company
    ADD CONSTRAINT company_pkey PRIMARY KEY (id);


--
-- TOC entry 2829 (class 2606 OID 17379)
-- Name: companyfunction companyfunction_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.companyfunction
    ADD CONSTRAINT companyfunction_pkey PRIMARY KEY (id);


--
-- TOC entry 2831 (class 2606 OID 17381)
-- Name: companytype companytype_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.companytype
    ADD CONSTRAINT companytype_pkey PRIMARY KEY (id);


--
-- TOC entry 2833 (class 2606 OID 17383)
-- Name: contact contact_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.contact
    ADD CONSTRAINT contact_pkey PRIMARY KEY (id);


--
-- TOC entry 2835 (class 2606 OID 17391)
-- Name: notification notification_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.notification
    ADD CONSTRAINT notification_pkey PRIMARY KEY (id);


--
-- TOC entry 2821 (class 2606 OID 17369)
-- Name: notificationtype notification_type_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.notificationtype
    ADD CONSTRAINT notification_type_pkey PRIMARY KEY (id);


--
-- TOC entry 2837 (class 2606 OID 17387)
-- Name: product product_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product
    ADD CONSTRAINT product_pkey PRIMARY KEY (id);


--
-- TOC entry 2839 (class 2606 OID 17393)
-- Name: users user_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT user_pkey PRIMARY KEY (id);


--
-- TOC entry 2845 (class 2606 OID 17394)
-- Name: company companyfunctionid_companyfunction_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.company
    ADD CONSTRAINT companyfunctionid_companyfunction_id FOREIGN KEY (companyfunctionid) REFERENCES public.companyfunction(id);


--
-- TOC entry 2840 (class 2606 OID 17399)
-- Name: address companyid_company-id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.address
    ADD CONSTRAINT "companyid_company-id" FOREIGN KEY (companyid) REFERENCES public.company(id);


--
-- TOC entry 2847 (class 2606 OID 17404)
-- Name: contact companyid_company-id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.contact
    ADD CONSTRAINT "companyid_company-id" FOREIGN KEY (companyid) REFERENCES public.company(id);


--
-- TOC entry 2850 (class 2606 OID 17409)
-- Name: product companyid_company-id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product
    ADD CONSTRAINT "companyid_company-id" FOREIGN KEY (companyid) REFERENCES public.company(id);


--
-- TOC entry 2852 (class 2606 OID 17419)
-- Name: users companyid_company-id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT "companyid_company-id" FOREIGN KEY (companyid) REFERENCES public.company(id);


--
-- TOC entry 2842 (class 2606 OID 17424)
-- Name: bid companyid_company_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.bid
    ADD CONSTRAINT companyid_company_id FOREIGN KEY (companyid) REFERENCES public.company(id);


--
-- TOC entry 2846 (class 2606 OID 17429)
-- Name: company companytypeid_companytype_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.company
    ADD CONSTRAINT companytypeid_companytype_id FOREIGN KEY (companytypeid) REFERENCES public.companytype(id);


--
-- TOC entry 2849 (class 2606 OID 17434)
-- Name: notification notificationtypeid_notificationtype_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.notification
    ADD CONSTRAINT notificationtypeid_notificationtype_id FOREIGN KEY (productupdatetypeid) REFERENCES public.notificationtype(id);


--
-- TOC entry 2843 (class 2606 OID 17454)
-- Name: bid productid_product_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.bid
    ADD CONSTRAINT productid_product_id FOREIGN KEY (productid) REFERENCES public.product(id);


--
-- TOC entry 2841 (class 2606 OID 17459)
-- Name: address userid_user_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.address
    ADD CONSTRAINT userid_user_id FOREIGN KEY (userid) REFERENCES public.users(id);


--
-- TOC entry 2848 (class 2606 OID 17464)
-- Name: contact userid_user_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.contact
    ADD CONSTRAINT userid_user_id FOREIGN KEY (userid) REFERENCES public.users(id);


--
-- TOC entry 2851 (class 2606 OID 17469)
-- Name: product userid_user_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product
    ADD CONSTRAINT userid_user_id FOREIGN KEY (userid) REFERENCES public.users(id);


--
-- TOC entry 2844 (class 2606 OID 17474)
-- Name: bid userid_user_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.bid
    ADD CONSTRAINT userid_user_id FOREIGN KEY (userid) REFERENCES public.users(id);


--
-- TOC entry 2999 (class 0 OID 0)
-- Dependencies: 196
-- Name: TABLE notificationtype; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON TABLE public.notificationtype TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3001 (class 0 OID 0)
-- Dependencies: 197
-- Name: SEQUENCE "ProductUpdateType_id_seq"; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON SEQUENCE public."ProductUpdateType_id_seq" TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3002 (class 0 OID 0)
-- Dependencies: 198
-- Name: TABLE address; Type: ACL; Schema: public; Owner: postgres
--


GRANT ALL ON TABLE public.address TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3004 (class 0 OID 0)
-- Dependencies: 199
-- Name: SEQUENCE address_id_seq; Type: ACL; Schema: public; Owner: postgres
--


GRANT ALL ON SEQUENCE public.address_id_seq TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3005 (class 0 OID 0)
-- Dependencies: 200
-- Name: TABLE bid; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON TABLE public.bid TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3007 (class 0 OID 0)
-- Dependencies: 201
-- Name: SEQUENCE bid_id_seq; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON SEQUENCE public.bid_id_seq TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3008 (class 0 OID 0)
-- Dependencies: 202
-- Name: TABLE company; Type: ACL; Schema: public; Owner: postgres
--


GRANT ALL ON TABLE public.company TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3010 (class 0 OID 0)
-- Dependencies: 203
-- Name: SEQUENCE company_id_seq; Type: ACL; Schema: public; Owner: postgres
--


GRANT ALL ON SEQUENCE public.company_id_seq TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3011 (class 0 OID 0)
-- Dependencies: 204
-- Name: TABLE companyfunction; Type: ACL; Schema: public; Owner: postgres
--


GRANT ALL ON TABLE public.companyfunction TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3013 (class 0 OID 0)
-- Dependencies: 205
-- Name: SEQUENCE companyfunction_id_seq; Type: ACL; Schema: public; Owner: postgres
--


GRANT ALL ON SEQUENCE public.companyfunction_id_seq TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3014 (class 0 OID 0)
-- Dependencies: 206
-- Name: TABLE companytype; Type: ACL; Schema: public; Owner: postgres
--


GRANT ALL ON TABLE public.companytype TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3016 (class 0 OID 0)
-- Dependencies: 207
-- Name: SEQUENCE companytype_id_seq; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON SEQUENCE public.companytype_id_seq TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3017 (class 0 OID 0)
-- Dependencies: 208
-- Name: TABLE contact; Type: ACL; Schema: public; Owner: postgres
--


GRANT ALL ON TABLE public.contact TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3019 (class 0 OID 0)
-- Dependencies: 209
-- Name: SEQUENCE contact_id_seq; Type: ACL; Schema: public; Owner: postgres
--


GRANT ALL ON SEQUENCE public.contact_id_seq TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3020 (class 0 OID 0)
-- Dependencies: 210
-- Name: TABLE notification; Type: ACL; Schema: public; Owner: postgres
--


GRANT ALL ON TABLE public.notification TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3021 (class 0 OID 0)
-- Dependencies: 211
-- Name: TABLE product; Type: ACL; Schema: public; Owner: postgres
--


GRANT ALL ON TABLE public.product TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3023 (class 0 OID 0)
-- Dependencies: 212
-- Name: SEQUENCE product_id_seq; Type: ACL; Schema: public; Owner: postgres
--


GRANT ALL ON SEQUENCE public.product_id_seq TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3025 (class 0 OID 0)
-- Dependencies: 213
-- Name: SEQUENCE product_reference_seq; Type: ACL; Schema: public; Owner: postgres
--


GRANT ALL ON SEQUENCE public.product_reference_seq TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3027 (class 0 OID 0)
-- Dependencies: 214
-- Name: SEQUENCE productupdate_id_seq; Type: ACL; Schema: public; Owner: postgres
--


GRANT ALL ON SEQUENCE public.productupdate_id_seq TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3028 (class 0 OID 0)
-- Dependencies: 215
-- Name: TABLE users; Type: ACL; Schema: public; Owner: postgres
--


GRANT ALL ON TABLE public.users TO "BiddingSystem-dev" WITH GRANT OPTION;


-- Completed on 2019-06-03 21:29:08

--
-- PostgreSQL database dump complete
--

