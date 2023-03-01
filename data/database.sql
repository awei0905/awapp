--
-- PostgreSQL database dump
--

-- Dumped from database version 9.6.24
-- Dumped by pg_dump version 9.6.24

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: DATABASE postgres; Type: COMMENT; Schema: -; Owner: postgres
--

COMMENT ON DATABASE postgres IS 'default administrative connection database';


--
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET default_tablespace = '';

SET default_with_oids = false;

--
-- Name: newtable; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.newtable (
    id integer NOT NULL,
    name character varying(255) NOT NULL
);


ALTER TABLE public.newtable OWNER TO postgres;

--
-- Name: newtable_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.newtable_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.newtable_id_seq OWNER TO postgres;

--
-- Name: newtable_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.newtable_id_seq OWNED BY public.newtable.id;


--
-- Name: newtable id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.newtable ALTER COLUMN id SET DEFAULT nextval('public.newtable_id_seq'::regclass);


--
-- Data for Name: newtable; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.newtable (id, name) FROM stdin;
1	Joe
2	Nick
3	Cindy
\.


--
-- Name: newtable_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.newtable_id_seq', 3, true);


--
-- Name: newtable newtable_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.newtable
    ADD CONSTRAINT newtable_pk PRIMARY KEY (id);


--
-- PostgreSQL database dump complete
--

