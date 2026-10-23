Podsumowanie Sprintu 1 🏁

Projekt: SimSetup Tracker

Zespół: Paweł Nawrocki

Czas trwania sprintu: 18.09.2026 – 02.10.2026

1. Realizacja Celu Sprintu (Sprint Goal)

Cel główny: Inicjalizacja projektu, utworzenie repozytorium oraz zaprojektowanie i wdrożenie podstawowych modeli obiektowych wraz z bazą danych (szkielet backendu w .NET Web API).

Status realizacji: ✅ Osiągnięty w 100%
Udało się z sukcesem skonfigurować czyste środowisko pracy, zaimplementować modele domenowe i połączyć je z bazą danych za pomocą Entity Framework Core. API kompiluje się bez błędów.

2. Zrealizowane Zadania (Sprint Backlog)

Wszystkie zaplanowane na ten sprint zadania zostały przeniesione do statusu "Done":

[x] Założenie repozytorium GitHub i inicjalizacja solucji: Utworzono poprawną strukturę katalogów (osobny folder solucji i projektu), dodano plik .gitignore oraz plik README.md.

[x] Projekt i implementacja modeli C#: Stworzono klasy obiektowe (Car, Track, Setup) zachowując zasady enkapsulacji i relacji (jeden-do-wielu).

[x] Konfiguracja Bazy Danych: Podłączono Entity Framework Core (z bazą SQLite dla środowiska deweloperskiego).

[x] Migracje: Pomyślnie wykonano komendę Update-Database, która utworzyła fizyczne tabele na podstawie modeli C#.

[x] Kontrolery API: Stworzono bazowy kontroler CarsController obsługujący zapytania typu CRUD (Create, Read, Update, Delete).

[x] Dokumentacja API: Skonfigurowano narzędzie Swagger do testowania endpointów z poziomu przeglądarki.

3. Aspekty Techniczne i Architektura

Projekt został zbudowany z myślą o przyszłej skalowalności (przewidywane dodanie interfejsu Web w Blazor oraz aplikacji mobilnej .NET MAUI w kolejnych miesiącach).

Zadbano o to, aby pliki tymczasowe kompilatora (bin/, obj/) nie zanieczyszczały repozytorium na GitHubie.

Wykorzystano wstrzykiwanie zależności (Dependency Injection) do obsługi kontekstu bazy danych (AppDbContext).

4. Wyzwania i Wnioski

Struktura repozytorium: Pojawiło się ryzyko wymieszania plików projektowych w głównym katalogu, jednak udało się temu zapobiec, wydzielając kod do podfolderu projektu (SimSetupTracker.Api) wewnątrz głównego katalogu solucji.

Wniosek na przyszłość: W kolejnym sprincie warto rozważyć wydzielenie modeli domenowych do osobnego projektu typu Class Library, aby ułatwić ich współdzielenie z przyszłym interfejsem użytkownika.

5. Plan na Sprint 2 (Zajawka)

W kolejnym etapie prac skupimy się na:

Rozbudowie kontrolerów API o modele Track i Setup.

Dodaniu walidacji danych wejściowych.

(Opcjonalnie) Inicjalizacji projektu frontendowego.
