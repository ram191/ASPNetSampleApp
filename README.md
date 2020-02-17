# Group 3

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
