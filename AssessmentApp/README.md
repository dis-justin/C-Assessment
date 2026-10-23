# C# Assessment

## Repository

[C-Assessment GitHub Repository](https://github.com.mcas.ms/dis-justin/C-Assessment)

## Instructions

1. **Set up the project**
   - Clone the repository.
   - Open the `AssessmentApp` project directory.
   - Restore the project dependencies:

     ```bash
     dotnet restore
     ```

   - Build the project:

     ```bash
     dotnet build
     ```

2. **Configure the model**
   - Correct the entity relationships in `Models/Event.cs`.
   - Follow the instructions provided in the project.
   - Configure the required relationships and Fluent API rules.

3. **Implement the endpoints**
   - Implement `GET /api/events`.
   - Implement `GET /api/events/{id}`.
   - Use asynchronous EF Core queries.
   - Project query results into `EventDto` objects.
   - Use `AsNoTracking()` for read-only queries where appropriate.

4. **Handle API responses**
   - Return `200 OK` when an event is found.
   - Return `404 Not Found` when the requested event does not exist.
   - Return an empty JSON collection when a collection query has no results.

5. **Test the application**
   - Run the application:

     ```bash
     dotnet run
     ```

   - Use Swagger, a browser, or another API client to test:
     - An existing event ID
     - A missing event ID
     - An empty result set
     - The complete events collection

6. **Submit the completed work**
   - Commit your changes.
   - Push the completed work to GitHub.

## Acceptance Criteria

The assessment is complete when:

- [ ] The application restores, builds, and runs successfully.
- [ ] Entity relationships and Fluent API rules are correctly configured.
- [ ] `GET /api/events` returns JSON containing `EventDto` objects.
- [ ] `GET /api/events/{id}` returns `200 OK` for an existing event.
- [ ] `GET /api/events/{id}` returns `404 Not Found` for a missing event.
- [ ] Read-only queries use asynchronous methods.
- [ ] `AsNoTracking()` is used where appropriate.
- [ ] All changes are committed and pushed to GitHub.