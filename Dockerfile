# Используем образ .NET SDK для сборки приложения
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Устанавливаем рабочую директорию
WORKDIR /app

# Копируем csproj и восстанавливаем зависимости
COPY *.csproj ./
RUN dotnet restore

# Копируем все файлы и собираем приложение
COPY . ./
RUN dotnet publish -c Release -o out

# Используем образ .NET Runtime для выполнения приложения
FROM mcr.microsoft.com/dotnet/runtime:6.0

# Устанавливаем рабочую директорию
WORKDIR /app

# Копируем собранное приложение из предыдущего этапа
COPY --from=build /app/out .

# Определяем точку входа
ENTRYPOINT ["dotnet", "AverageCalculator.dll"]

