# bamserver

A BAM protocol HTTP server application for handling BAM protocol requests over HTTP, TCP, and UDP.

## Overview

bamserver (packaged as "bamhttp") is a console application that serves as an HTTP server for the BAM protocol stack. It extends `CommandLineTool` and uses the BAM framework's command-line infrastructure with `TryWritePid`, `AddConfigurationSwitches`, and `ExecuteMainOrInteractive` for lifecycle management.

The project references `bam.protocol` (which defines the BAM protocol message types, request/response handling, authorization, and session state) and `bam.core`. The `Program.cs` is minimal -- it writes a PID file, adds configuration switches, and either executes the main command or enters interactive mode. The actual protocol handling logic resides in the referenced `bam.protocol` project.

The broader `bamserver` repository contains the `bam.protocol` library with server-side components (BamRequestProcessor, BamRequestReader, BamResponse, BamAuthorizationCalculator, BamSessionStateProvider, BamUserResolver) and client-side components (BamClient, HttpClientRequest, TcpClientRequest, UdpClientRequest). The bamserver executable ties these together as a runnable host.

## Key Classes

| Class | Description |
|---|---|
| `Program` | Entry point extending `CommandLineTool` with PID file, config switches, and interactive mode |

### Referenced Classes (from bam.protocol)

| Class | Description |
|---|---|
| `BamRequestProcessor` | Processes incoming BAM protocol requests (stub) |
| `BamRequestReader` | Reads and parses BAM protocol requests from HTTP contexts |
| `BamResponse` | Represents a BAM protocol response |
| `BamAuthorizationCalculator` | Calculates authorization for BAM requests (stub) |
| `BamSessionStateProvider` | Manages session state (stub) |
| `BamUserResolver` | Resolves users from requests (stub) |
| `BamClient` | Client for making BAM protocol requests |
| `HttpClientRequest` / `TcpClientRequest` / `UdpClientRequest` | Transport-specific client request implementations (stubs) |
| `DefaultBamResponseProvider` | Default response provider for BAM protocol (stub) |

## Dependencies

**Project References:**
- `bam.protocol` -- BAM protocol definitions and message handling
- `bam.core` (via bam.protocol) -- Core BAM framework

**Target Framework:** net6.0
**Output Type:** Exe
**RootNamespace:** Bam.Protocol
**PackageId/NuspecFile:** bamhttp

## Usage Examples

```bash
# Run the server
dotnet run --project bamserver

# The server writes a PID file and enters interactive mode
# Configuration switches can be passed as command-line arguments
```

## Known Gaps / Not Yet Implemented

The `bam.protocol` library that this server depends on has extensive stub implementations:

- **`BamAuthorizationCalculator`** -- throws `NotImplementedException`
- **`BamRequestProcessor`** -- throws `NotImplementedException`
- **`BamSessionStateProvider`** -- throws `NotImplementedException`
- **`BamUserResolver`** -- throws `NotImplementedException`
- **`DefaultBamResponseProvider`** -- all four methods throw `NotImplementedException`
- **`BamResponse`** -- two methods throw `NotImplementedException`
- **`HttpClientRequest`** -- `Send` and `SendAsync` throw `NotImplementedException`
- **`TcpClientRequest`** -- `Send` and `SendAsync` throw `NotImplementedException`
- **`UdpClientRequest`** -- `Send` and `SendAsync` throw `NotImplementedException`
- **`BamClient`** -- one method throws `NotImplementedException`
- **`BamRequestReader`** has a TODO comment: "ensure other request properties are set"
- The project targets net6.0, which is older than the net10.0 used by most other projects in the toolkit.
