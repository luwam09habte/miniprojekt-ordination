# Ordinationsprojekt – arbejdsplan

En lille kanban-plan for gruppen. Brug filen som fælles tjekliste; flyt opgaver fra **Næste** til **I gang** og derefter **Færdig**, når I aftaler det.

## Mål og afleveringer

- **Softwarearkitektur:** færdigimplementeret ordinationsmodel og service/API, MSTest-unit-tests, GitHub-link med al kode.
- **Systemudvikling:** dokumenterede black-box-testcases for centrale metoder samt testspecifikation til use casen **Opret ordination**.
- **Test på tværs af grupper:** udfør en anden gruppes use-case-testspecifikation mod deres system, og dokumentér resultatet.
- **Fremlæggelse:** cirka 7 minutter den 7. december med en kompleks metodes testforløb, use-case-testspecifikation, de tre ordinationstyper og erfaringen fra gruppetesten.

## Status ved planens start — 23. november 2026

- [x] GitHub-repository oprettet; seneste commit på `main` er synkroniseret med `origin/main`.
- [x] `ordination-test`-projektet med MSTest findes allerede.
- [x] SQLite-projektets lokale database er migreret; databasefilen ligger under `bin` og deles ikke via Git.
- [ ] Løsningen mangler stadig model- og servicefunktioner. MSTest-projektet har to demonstrations-tests, der skal erstattes/afklares, samt tomme `OpretDagligSkæv`- og `OpretPN`-tests.
- [ ] Ingen testresultater er bekræftet endnu.
- [ ] Ved planarbejdet viste `git status` lokale ændringer: slettede filer fra det gamle `OrdinationTest`-projekt, en `ordination.sln`-ændring der fjerner det projekt, samt nye tomme tests i `ordination-test/ServiceTest.cs`. Gennemgå dem før næste kode-commit; de er ikke ændret her. Planen selv er committed/pushet som `TODO.md`.

## Næste — start her

### 1. Aftal domæne-regler og testdata — straks, 23. november

- [ ] Brug fælles reglen `startdato < slutdato`; startdagen tæller med, slutdagen tæller ikke med.
- [ ] Afklar håndtering af PN uden registrerede doser. Foreslået: døgndosis `0`.
- [ ] Brug PN-reglen fra opgaven: antal givninger × enheder divideret med antal kalenderdage fra første til sidste givning, begge dage medregnet. Foreslået for én givning: nævner `1`.
- [ ] Fastlæg forventet fejl/returværdi for ugyldige ID'er, datoer og mængder, så model, API og tests bruger samme kontrakt.
- [ ] Lav konkrete testdata med dosisgrænser og vægte omkring `25 kg` og `120 kg`.

### 2. Færdiggør modelklasserne først — kodefristen er 23. november

- [ ] `Ordination.antalDage()`: hele kalenderdage, start inklusiv/slut eksklusiv.
- [ ] `DagligFast.doegnDosis()`: summér morgen, middag, aften og nat.
- [ ] `DagligSkæv.doegnDosis()`: summér alle registrerede doser for et døgn.
- [ ] `PN.givDosis()`: registrér kun datoer i gyldighedsperioden; tillad flere doser samme dato.
- [ ] `PN.doegnDosis()`: anvend PN-formlen fra opgaven.
- [ ] Kontrollér `samletDosis()` for alle tre typer mod periode- og PN-reglerne.

### 3. Black-box-testcases til 26. november; MSTest-kode til 4. december

- [ ] **26. november:** Lav en testcase-tabel med input, forventet resultat og dækket ækvivalensklasse/grænseværdi for `Ordination`, `DagligFast`, `DagligSkæv`, `PN` og udvalgte `DataService`-metoder.
- [ ] Erstat `PatientTest.TestDerAltidFejler` med meningsfulde assertions eller fjern demonstrations-testen.
- [ ] Erstat `ServiceTest.TestAtKodenSmiderEnException` med en test, der faktisk kalder kode med en dokumenteret forventet exception, eller fjern demonstrations-testen.
- [ ] Gør hver `ServiceTest` uafhængig: brug en unik InMemory-database pr. test eller ryd databasen mellem tests.
- [ ] **4. december:** Implementér MSTest for modelgrænserne og relevante service-success-/fejlscenarier.

### 4. Implementér DataService og forbind API'et — kodefristen er 23. november

- [ ] `OpretPN`: find patient og lægemiddel, opret og gem PN-ordinationen.
- [ ] `OpretDagligFast`: opret og gem de fire faste doser.
- [ ] `OpretDagligSkaev`: opret og gem den valgte liste af tid/dosis-par.
- [ ] `AnvendOrdination`: find PN-ordination, registrér dosisdato inden for perioden og returnér resultat.
- [ ] `GetAnbefaletDosisPerDøgn`: vælg let faktor under 25 kg, normal faktor fra 25 til og med 120 kg, tung faktor over 120 kg; gang faktor med vægt.
- [ ] Sikr at ugyldig start/slutdato afvises i overensstemmelse med use casen.
- [ ] Opdatér MSTest for hver servicefunktion.

### 5. Use-case-specifikation til 26. november; gruppetest til 4. december

- [ ] **26. november:** Skriv precondition, testdata, trin, forventede resultater og postcondition.
- [ ] Dæk oprettelse af PN, daglig fast og daglig skæv; medtag fejlflow for startdato efter slutdato.
- [ ] Medtag visning af anbefalet døgndosis og løbende summering for daglig skæv.
- [ ] **4. december:** Udfør en anden gruppes specifikation mod deres system; notér bestået/fejlet trin og reproducerbare fejl.
- [ ] Gem testcase-dokument og gruppetestresultat til Systemudvikling-afleveringen.

### 6. Kør hele løsningen og aflever kode/GitHub-link senest 4. december

- [ ] Kør MSTest og ret alle fejl; gem testresultatet som evidens.
- [ ] Start API og Blazor hver for sig; gennemfør mindst ét manuelt forløb for hver ordinationstype.
- [ ] Opdatér README: den siger nu .NET 6, mens projekterne er målrettet .NET 10. Beskriv korrekte startkommandoer og database-migration.
- [ ] Kontrollér at ingen build-filer, lokal database eller hemmeligheder er staged.
- [ ] Commit og push kodeændringer løbende; aflever GitHub-linket.

### 7. Klargør fremlæggelsen — 7. december

- [ ] Vælg én kompleks metode og vis hele forløbet: specifikation → testcase → MSTest → resultat.
- [ ] Vis testspecifikationen for “Opret ordination”.
- [ ] Vis kort implementeringen af `DagligFast`, `DagligSkæv` og `PN`.
- [ ] Rapportér resultatet af den anden gruppes test af jeres system.
- [ ] Øv en sammenhængende fremlæggelse på cirka 7 minutter.

## Backlog — ekstraopgave, kun hvis tid og overskud

- [ ] Beregn antal ordinationer med et bestemt lægemiddel for patienter inden for et vægtinterval.
- [ ] Tilføj besked, hvis den anbefalede døgndosis overskrides.

## Afhængigheder og noter

- Modelberegningerne bør være stabile, før API-funktionerne implementeres; ellers bliver både Blazor og service-tests sværere at fejlfinde.
- Opgavebeskrivelsen kræver ikke en bestemt database. Behold foreløbig den SQLite-konfiguration, som startprojektets API bruger; MSTest må fortsat bruge EF InMemory.
- Planens PN-regler ved nul eller én givning er tydelige foreslåede antagelser, fordi opgavebeskrivelsen ikke definerer de tilfælde eksplicit. Bekræft dem med underviser eller gruppen, før I låser testforventningerne.
