--
-- PostgreSQL database dump
--

-- Dumped from database version 11.2 (Debian 11.2-1.pgdg90+1)
-- Dumped by pg_dump version 11.2

-- Started on 2019-06-03 21:41:45

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 2999 (class 1262 OID 17251)
-- Name: biddingsystem-data-dev; Type: DATABASE; Schema: -; Owner: postgres
--



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
-- Name: TenderUpdateType_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."TenderUpdateType_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."TenderUpdateType_id_seq" OWNER TO postgres;

--
-- TOC entry 3002 (class 0 OID 0)
-- Dependencies: 197
-- Name: TenderUpdateType_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."TenderUpdateType_id_seq" OWNED BY public.notificationtype.id;


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
-- TOC entry 3005 (class 0 OID 0)
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
-- TOC entry 3008 (class 0 OID 0)
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
-- TOC entry 3011 (class 0 OID 0)
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
-- TOC entry 3014 (class 0 OID 0)
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
-- TOC entry 3017 (class 0 OID 0)
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
-- TOC entry 3020 (class 0 OID 0)
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
-- Name: tender_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.tender_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.tender_id_seq OWNER TO postgres;

--
-- TOC entry 3024 (class 0 OID 0)
-- Dependencies: 212
-- Name: tender_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.tender_id_seq OWNED BY public.product.id;


--
-- TOC entry 213 (class 1259 OID 17340)
-- Name: tender_reference_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.tender_reference_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.tender_reference_seq OWNER TO postgres;

--
-- TOC entry 3026 (class 0 OID 0)
-- Dependencies: 213
-- Name: tender_reference_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.tender_reference_seq OWNED BY public.product.reference;


--
-- TOC entry 214 (class 1259 OID 17347)
-- Name: tenderupdate_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.tenderupdate_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.tenderupdate_id_seq OWNER TO postgres;

--
-- TOC entry 3028 (class 0 OID 0)
-- Dependencies: 214
-- Name: tenderupdate_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.tenderupdate_id_seq OWNED BY public.notification.id;


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

ALTER TABLE ONLY public.notification ALTER COLUMN id SET DEFAULT nextval('public.tenderupdate_id_seq'::regclass);


--
-- TOC entry 2803 (class 2604 OID 17363)
-- Name: notificationtype id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.notificationtype ALTER COLUMN id SET DEFAULT nextval('public."TenderUpdateType_id_seq"'::regclass);


--
-- TOC entry 2818 (class 2604 OID 17365)
-- Name: product id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product ALTER COLUMN id SET DEFAULT nextval('public.tender_id_seq'::regclass);


--
-- TOC entry 2819 (class 2604 OID 17366)
-- Name: product reference; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.product ALTER COLUMN reference SET DEFAULT nextval('public.tender_reference_seq'::regclass);


--
-- TOC entry 2976 (class 0 OID 17260)
-- Dependencies: 198
-- Data for Name: address; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.address (id, addressline1, addressline2, city, country, county, postcode, userid, companyid) VALUES (1, '123', '123', '123', '123', '123', '123', '45d21446-af7b-463d-8028-0360600dd35e', 6);
INSERT INTO public.address (id, addressline1, addressline2, city, country, county, postcode, userid, companyid) VALUES (2, '213', '213', '123', '123', '123', '123', '0ab55e86-9ead-45ab-be2b-9399ceae0e3b', 7);
INSERT INTO public.address (id, addressline1, addressline2, city, country, county, postcode, userid, companyid) VALUES (3, '123', '123', '123', '123', '123', '123', '05ee8f22-c997-464d-a9d2-b5993f458244', 8);


--
-- TOC entry 2978 (class 0 OID 17268)
-- Dependencies: 200
-- Data for Name: bid; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.bid (id, productid, price, companyid, userid, cancelled, accepted, declined) VALUES (1, 7, 123, 6, '45d21446-af7b-463d-8028-0360600dd35e', true, false, false);
INSERT INTO public.bid (id, productid, price, companyid, userid, cancelled, accepted, declined) VALUES (3, 8, 15, 6, '45d21446-af7b-463d-8028-0360600dd35e', false, true, false);
INSERT INTO public.bid (id, productid, price, companyid, userid, cancelled, accepted, declined) VALUES (2, 8, 10, 6, '45d21446-af7b-463d-8028-0360600dd35e', false, false, true);
INSERT INTO public.bid (id, productid, price, companyid, userid, cancelled, accepted, declined) VALUES (4, 9, 324, 6, '45d21446-af7b-463d-8028-0360600dd35e', true, false, false);
INSERT INTO public.bid (id, productid, price, companyid, userid, cancelled, accepted, declined) VALUES (6, 9, 234, 6, '45d21446-af7b-463d-8028-0360600dd35e', false, true, false);
INSERT INTO public.bid (id, productid, price, companyid, userid, cancelled, accepted, declined) VALUES (5, 9, 234, 6, '45d21446-af7b-463d-8028-0360600dd35e', false, false, true);
INSERT INTO public.bid (id, productid, price, companyid, userid, cancelled, accepted, declined) VALUES (7, 10, 234, 6, '45d21446-af7b-463d-8028-0360600dd35e', true, false, false);
INSERT INTO public.bid (id, productid, price, companyid, userid, cancelled, accepted, declined) VALUES (9, 10, 234, 6, '45d21446-af7b-463d-8028-0360600dd35e', false, true, false);
INSERT INTO public.bid (id, productid, price, companyid, userid, cancelled, accepted, declined) VALUES (8, 10, 2343, 6, '45d21446-af7b-463d-8028-0360600dd35e', false, false, true);
INSERT INTO public.bid (id, productid, price, companyid, userid, cancelled, accepted, declined) VALUES (10, 11, 123, 6, '45d21446-af7b-463d-8028-0360600dd35e', false, true, false);
INSERT INTO public.bid (id, productid, price, companyid, userid, cancelled, accepted, declined) VALUES (11, 11, 12321, 6, '45d21446-af7b-463d-8028-0360600dd35e', false, false, true);


--
-- TOC entry 2980 (class 0 OID 17276)
-- Dependencies: 202
-- Data for Name: company; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.company (id, companynumber, companytypeid, companyfunctionid, logourl, companyname) VALUES (5, 123, 1, 1, NULL, '123');
INSERT INTO public.company (id, companynumber, companytypeid, companyfunctionid, logourl, companyname) VALUES (6, 123, 1, 1, NULL, '123');
INSERT INTO public.company (id, companynumber, companytypeid, companyfunctionid, logourl, companyname) VALUES (7, 123, 1, 1, NULL, '123');
INSERT INTO public.company (id, companynumber, companytypeid, companyfunctionid, logourl, companyname) VALUES (8, 123, 1, 2, NULL, '123');


--
-- TOC entry 2982 (class 0 OID 17289)
-- Dependencies: 204
-- Data for Name: companyfunction; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.companyfunction (id, name) VALUES (3, 'Other');
INSERT INTO public.companyfunction (id, name) VALUES (1, 'Supplier
');
INSERT INTO public.companyfunction (id, name) VALUES (2, 'Buyer');


--
-- TOC entry 2984 (class 0 OID 17297)
-- Dependencies: 206
-- Data for Name: companytype; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.companytype (id, name) VALUES (1, 'LTD');
INSERT INTO public.companytype (id, name) VALUES (2, 'PLC');
INSERT INTO public.companytype (id, name) VALUES (3, 'Solo');


--
-- TOC entry 2986 (class 0 OID 17305)
-- Dependencies: 208
-- Data for Name: contact; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.contact (id, firstname, middlename, lastname, jobtitle, phonenumber, secondaryphonenumber, userid, companyid) VALUES (1, 'tom', 'tom', 'tom', 'tom', '01234567890', '01234567890', '45d21446-af7b-463d-8028-0360600dd35e', 6);
INSERT INTO public.contact (id, firstname, middlename, lastname, jobtitle, phonenumber, secondaryphonenumber, userid, companyid) VALUES (2, '123', '123', '123', '123', '123', '123', '0ab55e86-9ead-45ab-be2b-9399ceae0e3b', 7);
INSERT INTO public.contact (id, firstname, middlename, lastname, jobtitle, phonenumber, secondaryphonenumber, userid, companyid) VALUES (3, '123', '123', '123', '123', '1234567890', '123', '05ee8f22-c997-464d-a9d2-b5993f458244', 8);


--
-- TOC entry 2988 (class 0 OID 17313)
-- Dependencies: 210
-- Data for Name: notification; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.notification (id, read, productupdatetypeid, duedate, information, datecreated, receivinguserid) VALUES (1, true, 1, '2019-06-06 00:00:00+00', 'Bid has been placed by 123 on product #00000007', '2019-06-03 18:03:50.709254+00', '05ee8f22-c997-464d-a9d2-b5993f458244');
INSERT INTO public.notification (id, read, productupdatetypeid, duedate, information, datecreated, receivinguserid) VALUES (4, true, 1, '2019-06-06 00:00:00+00', 'Bid has been placed by 123 on product #00000008', '2019-06-03 18:24:10.265685+00', '05ee8f22-c997-464d-a9d2-b5993f458244');
INSERT INTO public.notification (id, read, productupdatetypeid, duedate, information, datecreated, receivinguserid) VALUES (2, true, 1, '2019-06-06 00:00:00+00', 'Bid has been placed by 123 on product #00000008', '2019-06-03 18:23:23.108583+00', '05ee8f22-c997-464d-a9d2-b5993f458244');
INSERT INTO public.notification (id, read, productupdatetypeid, duedate, information, datecreated, receivinguserid) VALUES (12, true, 1, '0001-01-01 00:00:00+00', 'Your bid for product #00000009 has been declined and the product has been awarded.', '2019-06-03 19:23:01.355592+00', '45d21446-af7b-463d-8028-0360600dd35e');
INSERT INTO public.notification (id, read, productupdatetypeid, duedate, information, datecreated, receivinguserid) VALUES (11, true, 1, '0001-01-01 00:00:00+00', 'Your bid for product #00000009 has been accepted! You will be contacted shortly by the seller.', '2019-06-03 19:23:01.266113+00', '45d21446-af7b-463d-8028-0360600dd35e');
INSERT INTO public.notification (id, read, productupdatetypeid, duedate, information, datecreated, receivinguserid) VALUES (10, true, 1, '2019-06-06 00:00:00+00', 'Bid has been declined', '2019-06-03 19:23:00.209652+00', '45d21446-af7b-463d-8028-0360600dd35e');
INSERT INTO public.notification (id, read, productupdatetypeid, duedate, information, datecreated, receivinguserid) VALUES (6, true, 1, '0001-01-01 00:00:00+00', 'Your bid for product #00000008 has been declined and the product has been awarded.', '2019-06-03 18:24:20.207469+00', '45d21446-af7b-463d-8028-0360600dd35e');
INSERT INTO public.notification (id, read, productupdatetypeid, duedate, information, datecreated, receivinguserid) VALUES (5, true, 1, '0001-01-01 00:00:00+00', 'Your bid for product #00000008 has been accepted! You will be contacted shortly by the buyer.', '2019-06-03 18:24:20.117594+00', '45d21446-af7b-463d-8028-0360600dd35e');
INSERT INTO public.notification (id, read, productupdatetypeid, duedate, information, datecreated, receivinguserid) VALUES (3, true, 1, '2019-06-06 00:00:00+00', 'Bid has been declined', '2019-06-03 18:23:57.217283+00', '45d21446-af7b-463d-8028-0360600dd35e');
INSERT INTO public.notification (id, read, productupdatetypeid, duedate, information, datecreated, receivinguserid) VALUES (16, true, 1, '2019-06-06 00:00:00+00', 'Bid has been declined', '2019-06-03 19:25:31.631498+00', '45d21446-af7b-463d-8028-0360600dd35e');
INSERT INTO public.notification (id, read, productupdatetypeid, duedate, information, datecreated, receivinguserid) VALUES (17, true, 1, '0001-01-01 00:00:00+00', 'Your bid for product #00000010 has been accepted! You will be contacted shortly by the seller.', '2019-06-03 19:25:32.977329+00', '45d21446-af7b-463d-8028-0360600dd35e');
INSERT INTO public.notification (id, read, productupdatetypeid, duedate, information, datecreated, receivinguserid) VALUES (15, true, 1, '2019-06-06 00:00:00+00', 'Bid has been placed by 123 on product #00000010', '2019-06-03 19:23:52.049455+00', '05ee8f22-c997-464d-a9d2-b5993f458244');
INSERT INTO public.notification (id, read, productupdatetypeid, duedate, information, datecreated, receivinguserid) VALUES (13, true, 1, '2019-06-06 00:00:00+00', 'Bid has been placed by 123 on product #00000010', '2019-06-03 19:23:40.435599+00', '05ee8f22-c997-464d-a9d2-b5993f458244');
INSERT INTO public.notification (id, read, productupdatetypeid, duedate, information, datecreated, receivinguserid) VALUES (9, true, 1, '2019-06-06 00:00:00+00', 'Bid has been placed by 123 on product #00000009', '2019-06-03 19:22:56.805565+00', '05ee8f22-c997-464d-a9d2-b5993f458244');
INSERT INTO public.notification (id, read, productupdatetypeid, duedate, information, datecreated, receivinguserid) VALUES (8, true, 1, '2019-06-06 00:00:00+00', 'Bid has been placed by 123 on product #00000009', '2019-06-03 19:22:45.655609+00', '05ee8f22-c997-464d-a9d2-b5993f458244');
INSERT INTO public.notification (id, read, productupdatetypeid, duedate, information, datecreated, receivinguserid) VALUES (7, true, 1, '2019-06-06 00:00:00+00', 'Bid has been placed by 123 on product #00000009', '2019-06-03 19:22:28.4793+00', '05ee8f22-c997-464d-a9d2-b5993f458244');
INSERT INTO public.notification (id, read, productupdatetypeid, duedate, information, datecreated, receivinguserid) VALUES (14, true, 1, '2019-06-06 00:00:00+00', 'Bid has been placed by 123 on product #00000010', '2019-06-03 19:23:43.57646+00', '05ee8f22-c997-464d-a9d2-b5993f458244');
INSERT INTO public.notification (id, read, productupdatetypeid, duedate, information, datecreated, receivinguserid) VALUES (18, false, 1, '2019-06-06 00:00:00+00', 'Bid has been placed by 123 on product #00000011', '2019-06-03 19:32:15.396895+00', '05ee8f22-c997-464d-a9d2-b5993f458244');
INSERT INTO public.notification (id, read, productupdatetypeid, duedate, information, datecreated, receivinguserid) VALUES (19, false, 1, '2019-06-06 00:00:00+00', 'Bid has been placed by 123 on product #00000011', '2019-06-03 19:32:18.417798+00', '05ee8f22-c997-464d-a9d2-b5993f458244');
INSERT INTO public.notification (id, read, productupdatetypeid, duedate, information, datecreated, receivinguserid) VALUES (21, true, 1, '2019-06-06 00:00:00+00', 'Bid has been declined', '2019-06-03 19:32:31.953954+00', '45d21446-af7b-463d-8028-0360600dd35e');
INSERT INTO public.notification (id, read, productupdatetypeid, duedate, information, datecreated, receivinguserid) VALUES (20, true, 1, '0001-01-01 00:00:00+00', 'Your bid for product #00000011 has been accepted! You will be contacted shortly by the seller.', '2019-06-03 19:32:23.889982+00', '45d21446-af7b-463d-8028-0360600dd35e');


--
-- TOC entry 2974 (class 0 OID 17252)
-- Dependencies: 196
-- Data for Name: notificationtype; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.notificationtype (id, name) VALUES (1, 'Bid');
INSERT INTO public.notificationtype (id, name) VALUES (2, 'Product created');


--
-- TOC entry 2989 (class 0 OID 17330)
-- Dependencies: 211
-- Data for Name: product; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.product (id, reference, title, description, companyid, userid, cost, datecreated, enddate, cancelled) VALUES (7, 7, 'wefwefwe', '<p>23432423423423</p>', 8, '05ee8f22-c997-464d-a9d2-b5993f458244', 0, '2019-06-03 18:49:24.684475+00', '2019-06-13 00:00:00+00', true);
INSERT INTO public.product (id, reference, title, description, companyid, userid, cost, datecreated, enddate, cancelled) VALUES (8, 8, 'cassette tape (tdk)', '<p>TDK SA 90 best type 2 </p>', 8, '05ee8f22-c997-464d-a9d2-b5993f458244', 0, '2019-06-03 19:23:09.950859+00', '2019-06-07 00:00:00+00', true);
INSERT INTO public.product (id, reference, title, description, companyid, userid, cost, datecreated, enddate, cancelled) VALUES (9, 9, 'test', '<p>324</p>', 8, '05ee8f22-c997-464d-a9d2-b5993f458244', 0, '2019-06-03 20:22:18.51782+00', '2019-06-04 00:00:00+00', true);
INSERT INTO public.product (id, reference, title, description, companyid, userid, cost, datecreated, enddate, cancelled) VALUES (10, 10, '4353', '<p>234</p>', 8, '05ee8f22-c997-464d-a9d2-b5993f458244', 0, '2019-06-03 20:23:32.036055+00', '2019-06-04 00:00:00+00', true);
INSERT INTO public.product (id, reference, title, description, companyid, userid, cost, datecreated, enddate, cancelled) VALUES (11, 11, 'hello darkness', '<p>123</p>', 8, '05ee8f22-c997-464d-a9d2-b5993f458244', 0, '2019-06-03 20:30:59.235327+00', '2019-06-04 00:00:00+00', false);


--
-- TOC entry 2993 (class 0 OID 17349)
-- Dependencies: 215
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.users (id, username, password, companyid) VALUES ('45d21446-af7b-463d-8028-0360600dd35e', 'tmjwid@aol.com', 'AQAAAAEAACcQAAAAEOvNAY3FvVI4iuIZOKoZeyA9DfXbKTF8LQo2ZLZPBSFRfwDaDM/qRuj8FuObt0dymw==', 6);
INSERT INTO public.users (id, username, password, companyid) VALUES ('0ab55e86-9ead-45ab-be2b-9399ceae0e3b', 'tmjwid@aol.com1', 'AQAAAAEAACcQAAAAEIG8PMwivWiHk8piSzLokqAt47ms7lzM5CWIdeAsIvCTfL/P2qPqV46i84k6pwXqIQ==', 7);
INSERT INTO public.users (id, username, password, companyid) VALUES ('05ee8f22-c997-464d-a9d2-b5993f458244', 'tmjwid@aol.com2', 'AQAAAAEAACcQAAAAEBpACkG7TznJ7GH3QdzRVaCKlHXFc6t0BVLQLpfDXPKO2Q15sg5VJiLo+8UjSsBH+A==', 8);


--
-- TOC entry 3031 (class 0 OID 0)
-- Dependencies: 197
-- Name: TenderUpdateType_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."TenderUpdateType_id_seq"', 2, true);


--
-- TOC entry 3032 (class 0 OID 0)
-- Dependencies: 199
-- Name: address_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.address_id_seq', 3, true);


--
-- TOC entry 3033 (class 0 OID 0)
-- Dependencies: 201
-- Name: bid_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.bid_id_seq', 11, true);


--
-- TOC entry 3034 (class 0 OID 0)
-- Dependencies: 203
-- Name: company_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.company_id_seq', 8, true);


--
-- TOC entry 3035 (class 0 OID 0)
-- Dependencies: 205
-- Name: companyfunction_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.companyfunction_id_seq', 3, true);


--
-- TOC entry 3036 (class 0 OID 0)
-- Dependencies: 207
-- Name: companytype_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.companytype_id_seq', 3, true);


--
-- TOC entry 3037 (class 0 OID 0)
-- Dependencies: 209
-- Name: contact_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.contact_id_seq', 3, true);


--
-- TOC entry 3038 (class 0 OID 0)
-- Dependencies: 212
-- Name: tender_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.tender_id_seq', 11, true);


--
-- TOC entry 3039 (class 0 OID 0)
-- Dependencies: 213
-- Name: tender_reference_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.tender_reference_seq', 11, true);


--
-- TOC entry 3040 (class 0 OID 0)
-- Dependencies: 214
-- Name: tenderupdate_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.tenderupdate_id_seq', 21, true);


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
-- TOC entry 3000 (class 0 OID 0)
-- Dependencies: 2999
-- Name: DATABASE "biddingsystem-data-dev"; Type: ACL; Schema: -; Owner: postgres
--

GRANT ALL ON DATABASE "biddingsystem-data-dev" TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3001 (class 0 OID 0)
-- Dependencies: 196
-- Name: TABLE notificationtype; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON TABLE public.notificationtype TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3003 (class 0 OID 0)
-- Dependencies: 197
-- Name: SEQUENCE "TenderUpdateType_id_seq"; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON SEQUENCE public."TenderUpdateType_id_seq" TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3004 (class 0 OID 0)
-- Dependencies: 198
-- Name: TABLE address; Type: ACL; Schema: public; Owner: postgres
--


GRANT ALL ON TABLE public.address TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3006 (class 0 OID 0)
-- Dependencies: 199
-- Name: SEQUENCE address_id_seq; Type: ACL; Schema: public; Owner: postgres
--


GRANT ALL ON SEQUENCE public.address_id_seq TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3007 (class 0 OID 0)
-- Dependencies: 200
-- Name: TABLE bid; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON TABLE public.bid TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3009 (class 0 OID 0)
-- Dependencies: 201
-- Name: SEQUENCE bid_id_seq; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON SEQUENCE public.bid_id_seq TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3010 (class 0 OID 0)
-- Dependencies: 202
-- Name: TABLE company; Type: ACL; Schema: public; Owner: postgres
--


GRANT ALL ON TABLE public.company TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3012 (class 0 OID 0)
-- Dependencies: 203
-- Name: SEQUENCE company_id_seq; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON SEQUENCE public.company_id_seq TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3013 (class 0 OID 0)
-- Dependencies: 204
-- Name: TABLE companyfunction; Type: ACL; Schema: public; Owner: postgres
--


GRANT ALL ON TABLE public.companyfunction TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3015 (class 0 OID 0)
-- Dependencies: 205
-- Name: SEQUENCE companyfunction_id_seq; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON SEQUENCE public.companyfunction_id_seq TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3016 (class 0 OID 0)
-- Dependencies: 206
-- Name: TABLE companytype; Type: ACL; Schema: public; Owner: postgres
--


GRANT ALL ON TABLE public.companytype TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3018 (class 0 OID 0)
-- Dependencies: 207
-- Name: SEQUENCE companytype_id_seq; Type: ACL; Schema: public; Owner: postgres
--


GRANT ALL ON SEQUENCE public.companytype_id_seq TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3019 (class 0 OID 0)
-- Dependencies: 208
-- Name: TABLE contact; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON TABLE public.contact TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3021 (class 0 OID 0)
-- Dependencies: 209
-- Name: SEQUENCE contact_id_seq; Type: ACL; Schema: public; Owner: postgres
--


GRANT ALL ON SEQUENCE public.contact_id_seq TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3022 (class 0 OID 0)
-- Dependencies: 210
-- Name: TABLE notification; Type: ACL; Schema: public; Owner: postgres
--


GRANT ALL ON TABLE public.notification TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3023 (class 0 OID 0)
-- Dependencies: 211
-- Name: TABLE product; Type: ACL; Schema: public; Owner: postgres
--


GRANT ALL ON TABLE public.product TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3025 (class 0 OID 0)
-- Dependencies: 212
-- Name: SEQUENCE tender_id_seq; Type: ACL; Schema: public; Owner: postgres
--


GRANT ALL ON SEQUENCE public.tender_id_seq TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3027 (class 0 OID 0)
-- Dependencies: 213
-- Name: SEQUENCE tender_reference_seq; Type: ACL; Schema: public; Owner: postgres
--

GRANT ALL ON SEQUENCE public.tender_reference_seq TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3029 (class 0 OID 0)
-- Dependencies: 214
-- Name: SEQUENCE tenderupdate_id_seq; Type: ACL; Schema: public; Owner: postgres
--


GRANT ALL ON SEQUENCE public.tenderupdate_id_seq TO "BiddingSystem-dev" WITH GRANT OPTION;


--
-- TOC entry 3030 (class 0 OID 0)
-- Dependencies: 215
-- Name: TABLE users; Type: ACL; Schema: public; Owner: postgres
--


GRANT ALL ON TABLE public.users TO "BiddingSystem-dev" WITH GRANT OPTION;


-- Completed on 2019-06-03 21:41:51

--
-- PostgreSQL database dump complete
--

