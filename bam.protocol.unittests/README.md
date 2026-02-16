# bam.protocol.unittests

Unit tests for the `bam.protocol` (bamserver) library.

## Overview

This project contains unit tests for the bamserver protocol library, covering both client and server components. Tests use the bam test framework with `[UnitTestMenu]` attributes and the `When.A<T>()` fluent API.

## Test Classes

| Class | Description |
|-------|-------------|
| `BamClientShould` | Tests for `BamClient` connectivity and request sending |
| `BamClientRequestBuilderShould` | Tests for building client requests across transports |
| `BamServerBuilderShould` | Tests for the server builder fluent API |
| `BamServerShould` | Tests for server start/stop and request handling |
| `RequestLineShould` | Tests for HTTP-style request line parsing |
| `RequestReaderShould` | Tests for stream-based request reading |
| `TestRequestReader` | Test double for `IBamRequestReader` |

## Dependencies

- **Project References:** `bamserver`
- **Target Framework:** `net6.0`
- **Output Type:** Exe (console test runner)

## Running Tests

```bash
dotnet run --project submodules/bamserver/bam.protocol.unittests/bam.protocol.unittests.csproj -- --ut
```

## Known Gaps

- Tests target `net6.0` (legacy); may not build against current `net10.0` dependencies without updates
