# Contacts API

## Правки, которые я бы внес при наличии времени
1. Для обновления контакта стоит использовать JsonMergePatchDocument из библиотеки https://github.com/Morcatko/Morcatko.AspNetCore.JsonMergePatch
т.к. модель имеет три состояния и в случае, если не передается поле, его не стоит обновлять
2. Возвращать более реперезентативные ответы при создании, удалении и обновлении записи

## Фичи которые я заложил, но не успел реализовать
1. Добавить список мессенджеров к контакту