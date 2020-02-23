# Assignment Description

This project is a project for two assignments. Both instructions are written below.
For assignment number 2, the request will be rejected as 403 forbidden if the request host is 'http://localhost:5000'. The allowed host for accessing the files is 'https://localhost:5001'.

Dependency Injection is added to Member Controller to be able to access data hosted on heroku app.

# Assignment 1 (Web API)

## Categories Table
| name        | key |
|-------------|-----|
| id          | PK  |
| name        |     |
| description |     |


## REST API URL

| url           | method | params |
|---------------|--------|--------|
| categories    | POST   |        |
| categories/id | PATCH  | id     |
| categories/id | DELETE | id     |
| categories    | GET    |        |
| categories/id | GET    | id     |

## Member Table

| name       | key |
|------------|-----|
| id         | PK  |
| username   |     |
| password   |     |
| email      |     |
| full_name  |     |
| popularity |     |


## REST API URL

| url     | method | params |
|---------|--------|--------|
| member    | POST   |        |
| member/id | PATCH  | id     |
| member/id | DELETE | id     |
| member    | GET    |        |
| member/id | GET    | id     |


## Topic Table
| name      | key |
|-----------|-----|
| id        | PK  |
| content   |     |
| title     |     |
| member_id | FK  |

## Topic REST API URL

| url      | method | params |
|----------|--------|--------|
| topic    | POST   |        |
| topic/id | PATCH  | id     |
| topic/id | DELETE | id     |
| topic    | GET    |        |
| topic/id | GET    | id     |

## Replies Table


| name      | key |
|-----------|-----|
| id        | PK  |
| content   |     |
| member_id | FK  |
| topic_id  | FK  |

## Replies REST API URL

| url        | method | params |
|------------|--------|--------|
| replies    | POST   |        |
| replies/id | PATCH  | id     |
| replies/id | DELETE | id     |
| replies    | GET    |        |
| replies/id | GET    | id     |

# Assignment 2 (Middleware)
create middleware to handle request on spesific request address host and save response to file 
```
[2020-02-20T11:13:54.545] Started GET /api/url for 10.0.0.1
[2020-02-20T11:13:54.550] Completed 403 /api/url for /api/url not allowed for 10.0.0.1
```
