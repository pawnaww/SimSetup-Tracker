# SimSetup Tracker 🏁

SimSetup Tracker to webowa aplikacja w C# / .NET służąca do zarządzania konfiguracjami samochodów (setupami) w grach simracingowych (np. Assetto Corsa) i śledzenia wpływu tych ustawień na czasy okrążeń na poszczególnych torach.

---

## 1. Informacje podstawowe
* **Nazwa projektu:** SimSetup Tracker
* **Skład drużyny:** Paweł Nawrocki
* **Krótki opis pomysłu:** Zewnętrzne narzędzie analityczne z własną bazą danych, pozwalające na kategoryzowanie, archiwizowanie i zestawianie ustawień aut, pomagające odpowiedzieć na pytanie, czy dane zmiany mechaniczne poprawiły tempo wyścigowe.

## 2. Cel projektu
* **Co chcieliśmy stworzyć?** Narzędzie analityczne pozwalające na śledzenie historii zmian w samochodzie wyścigowym.
* **Jaki problem / potrzebę projekt ma rozwiązywać?** Gracze często gubią się w tym, czy obniżenie ciśnienia w oponach lub zmiana kątów nachylenia kół ostatecznie poprawiła ich czas. Aplikacja rozwiązuje problem braku przejrzystego systemu do weryfikacji tych danych.
* **Dla kogo jest projekt?** Dla graczy simracingowych, inżynierów wyścigowych amatorów i pasjonatów symulatorów.
* **Co użytkownik będzie mógł dzięki niemu zrobić?** Dodać wybrany samochód i tor, wprowadzić kluczowe parametry telemetryczne/mechaniczne, przypisać uzyskany czas okrążenia, a następnie porównać wyniki dla różnych konfiguracji.

## 3. Plan i zakres projektu
* **Najważniejsze funkcje (MVP):** Formularze wprowadzania danych (modele: Auto, Tor, Setup, Czas), widok tabelaryczny historii przejazdów, proste filtrowanie po torze i samochodzie.
* **Co projekt musi posiadać:** Backend napisany w C# (np. .NET Core Web API), zastosowane zasady programowania obiektowego, relacyjną bazę danych z wykorzystaniem Entity Framework Core oraz interfejs graficzny w przeglądarce.
* **Jakie funkcje są dodatkowe / opcjonalne:** Integracja z telemetrią na żywo (skrypt Python nasłuchujący protokołu UDP z gry), przeniesienie i kompilacja interfejsu na urządzenia mobilne (Android/iOS) przy pomocy .NET MAUI, generowanie wykresów w czasie rzeczywistym.
* **Przewidywany efekt końcowy:** Uruchamialna, w pełni funkcjonalna aplikacja webowa z własnym API i wersjonowanym repozytorium na GitHubie.

## 4. Podział pracy
* **Konfiguracja środowiska i GitHub:** Założenie solucji w Visual Studio, organizacja repozytorium.
* **Backend & Baza Danych:** Zaprojektowanie diagramu klas, implementacja modeli w C#, utworzenie migracji Entity Framework, stworzenie kontrolerów API.
* **Frontend:** Budowa interfejsów webowych, formularzy i widoków tabel podłączonych do API.

---

## SPRINT PLANNING 
**Sprint:** 18.09 – 02.10  
**Zespół:** Paweł Nawrocki  
**Nazwa projektu:** SimSetup Tracker  

### 1. SPRINT GOAL 
* **Jaki jest główny cel tego sprintu?** Inicjalizacja projektu, utworzenie repozytorium oraz zaprojektowanie i wdrożenie podstawowych modeli obiektowych wraz z bazą danych.
* **Po zakończeniu sprintu chcemy osiągnąć:** Działający szkielet backendu w .NET Web API z podłączoną bazą danych (Entity Framework Core) i poprawnie skonfigurowanym repozytorium.
* **Najważniejszy rezultat sprintu:** Uruchamiające się API, które bez błędów kompilacji mapuje klasy C# na tabele w bazie danych.

### 2. SPRINT BACKLOG 
| # | Zadanie | Odpowiedzialny | Priorytet | Termin | Status |
|---|---|---|---|---|---|
| 1 | Założenie repozytorium GitHub i inicjalizacja solucji w Visual Studio | Paweł Nawrocki | 🔴 Must have | 19.09 | To Do |
| 2 | Projekt diagramu klas dla obiektów domenowych (Car, Track, Setup) | Paweł Nawrocki | 🔴 Must have | 20.09 | To Do |
| 3 | Implementacja modeli w C# z użyciem zasad enkapsulacji | Paweł Nawrocki | 🔴 Must have | 24.09 | To Do |
| 4 | Konfiguracja Entity Framework Core i połączenia z bazą | Paweł Nawrocki | 🔴 Must have | 27.09 | To Do |
| 5 | Wykonanie pierwszej migracji bazy danych (Update-Database) | Paweł Nawrocki | 🟡 Should have | 29.09 | To Do |
| 6 | Stworzenie bazowych kontrolerów API (CRUD) dla obiektów "Car" | Paweł Nawrocki | 🟡 Should have | 02.10 | To Do |
| 7 | Utworzenie testowych dokumentacji żądań HTTP (np. Swagger) | Paweł Nawrocki | 🟢 Could have | 02.10 | To Do |

**Priorytet:** 🔴 Must have | 🟡 Should have | 🟢 Could have

### 3. PLAN PRACY W SPRINCIE 

**Tydzień 1 — 18.09 → 25.09** 
* **Co chcemy mieć zrobione do 25.09?** Gotowe repozytorium kodu na GitHubie, czystą strukturę folderów w Visual Studio oraz w pełni zakodowane modele klas w C#, gotowe do zmapowania w bazie danych.
* **Checkpoint 1:** Czy jesteśmy zgodnie z planem? [ ] Tak [ ] Częściowo [ ] Nie
* **Co trzeba zmienić w planie?** *(Miejsce na notatki)*

**Tydzień 2 — 25.09 → 02.10** 
* **Co chcemy mieć zrobione do 02.10?** Skonfigurowany Entity Framework, wygenerowane tabele w bazie danych poprzez system migracji oraz przygotowane pierwsze proste endpointy API do testowania dodawania danych.
* **Checkpoint 2:** Czy jesteśmy zgodnie z planem? [ ] Tak [ ] Częściowo [ ] Nie
* **Co trzeba zmienić w planie?** *(Miejsce na notatki)*

**Koniec sprintu — 02.10** 
* **Co ostatecznie musi być gotowe?** Kompilująca się solucja, w której stworzenie nowego obiektu w kodzie odzwierciedla się w fizycznej tabeli bazy danych, a kod jest zapisany (commit) na głównej gałęzi w repozytorium.

### 4. PODZIAŁ ODPOWIEDZIALNOŚCI 
| Obszar / zadanie | Osoba odpowiedzialna | Współpracuje |
|---|---|---|
| Architektura i Modele C# | Paweł Nawrocki | - |
| Infrastruktura Bazy (EF Core) | Paweł Nawrocki | - |
| Zarządzanie repozytorium GitHub | Paweł Nawrocki | - |



### 5. ZALEŻNOŚCI I RYZYKA 
* **Od czego zależy wykonanie naszych zadań?** Od poprawnej instalacji pakietów NuGet dla Entity Framework, braku konfliktów w środowisku .NET i dostępu do dokumentacji.
* **Co może spowodować opóźnienie?** Błędy w logicznym powiązaniu relacji między tabelami (np. jeden-do-wielu dla Car -> Setup) podczas tworzenia migracji bazy danych lub problemy z synchronizacją z serwerem GitHub.
* **Jak możemy zareagować, jeśli pojawi się problem?** Uprościć strukturę bazy do jednej, "płaskiej" tabeli w celu zrealizowania minimum na zaliczenie sprintu. Poszukać rozwiązania specyficznych wyjątków kompilatora w dokumentacji Microsoft lub na StackOverflow.
