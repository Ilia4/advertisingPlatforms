# Advertising Platforms API

Простой веб-сервис на C# (.NET 8), позволяющий загружать рекламные площадки из файла и искать их по заданной локации.

## Функциональность

-  Загрузка рекламных площадок из файла (`platforms.txt`)
-  Поиск рекламных площадок, подходящих для указанной локации
-  Хранение данных в оперативной памяти (in-memory)
-  Быстрый поиск по вложенным локациям

## Пример входного файла
Яндекс.Директ:/ru

Ревдинский рабочий:/ru/svrd/revda,/ru/svrd/pervik

Газета уральских москвичей:/ru/msk,/ru/permobl,/ru/chelobl

Крутая реклама:/ru/svrd

### `POST /api/AdPlatform/load`

Загружает данные из файла `platforms.txt`, находящегося в корне проекта.

**Request:**
```json
"any"
```

**Response:**
```json
"Файл успешно загружен"
```

### POST /api/AdPlatform/search

Ищет рекламные площадки, подходящие для указанной локации.

**Request:**
```json
"/ru/svrd/revda"
```

**Response:**
```json
[
  "Яндекс.Директ",
  "Ревдинский рабочий",
  "Крутая реклама"
]
```

## Как запустить

1. Установите .NET 8 SDK
2. Клонируйте репозиторий:
  ```powershell
  git clone https://github.com/your-username/advertising-platforms-api.git

  cd advertising-platforms-api
```
