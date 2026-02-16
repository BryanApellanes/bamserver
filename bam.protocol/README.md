# bam.protocol (bamserver)

Low-level networking protocol library for the Bam server framework.

## Overview

This is the original protocol implementation used by `bamserver`. It provides a custom request/response protocol that operates over HTTP, TCP, and UDP transports. The library defines the full server-side pipeline including request reading, routing, authentication, authorization, session state, and response generation.

The client side provides `BamClient` with transport-specific request builders (`HttpBamClientRequestBuilder`, `TcpBamClientRequestBuilder`, `UdpBamClientRequestBuilder`) for communicating with a `BamServer`.

> **Note:** This project targets `net6.0` and references the legacy `bam.core` library. The newer `bam.protocol` submodule under `submodules/bam.protocol/` is the active replacement targeting `net10.0`.

## Key Classes

| Class | Description |
|-------|-------------|
| `BamServer` | Core server that listens for and processes incoming requests |
| `BamServerBuilder` | Fluent builder for configuring and creating `BamServer` instances |
| `BamRequest` / `BamResponse` | Request and response message types |
| `BamRequestReader` | Reads and parses incoming request data from streams |
| `BamRequestProcessor` | Routes requests to handlers |
| `BamClient` | Client for sending requests to a `BamServer` |
| `HttpBamClientRequestBuilder` | Builds HTTP transport requests |
| `TcpBamClientRequestBuilder` | Builds TCP transport requests |
| `UdpBamClientRequestBuilder` | Builds UDP transport requests |
| `BamContext` | Per-request context (identity, session, request/response) |
| `BamAuthentication` | Authentication handling |
| `BamAuthorizationCalculation` | Authorization decision computation |
| `BamSessionStateProvider` | In-memory session state management |
| `BamHostBinding` | Host/port/protocol binding configuration |

## Dependencies

- **Project References:** `bam.core`
- **Target Framework:** `net6.0`

## Usage Example

```csharp
// Build and start a server
BamServer server = new BamServerBuilder()
    .UseHostBinding(new BamHostBinding("localhost", 8080))
    .Build();

server.Start();

// Create a client and send a request
BamClient client = new BamClient("localhost", 8080);
IBamClientResponse response = await client.SendAsync(request);
```

## Known Gaps / Not Yet Implemented

- **Legacy target framework:** Targets `net6.0`; the newer `bam.protocol` submodule targets `net10.0`
- **UDP client request builder:** `UdpBamClientRequestBuilder` and `UdpClientRequest` may be incomplete stubs
- **No TLS/SSL configuration** visible in the server options
- **Session state** is in-memory only with no distributed or persistent option
