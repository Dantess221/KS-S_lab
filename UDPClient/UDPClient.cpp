// UDPClient.cpp
//

#include "stdafx.h"


int main()
{
	constexpr auto cli_socket = INVALID_SOCKET;
	WSADATA wsaData;

	const auto errorcode = WSAStartup(MAKEWORD(2, 2), &wsaData);
	if (errorcode != 0)
	{
		printf("WSAStartup failed: %d\n", errorcode);
		WSACleanup();
		return 1;
	}

	struct sockaddr_in serveraddr;  
	constexpr auto serv_addr = "192.168.1.101";
	constexpr u_short serv_port = 12345;


	const int sockfd = socket(2, 2, 0);

	
	memset(&serveraddr, 0, sizeof(serveraddr));
	serveraddr.sin_family = AF_INET;
	serveraddr.sin_addr.s_addr = inet_addr(serv_addr);
	serveraddr.sin_port = htons(serv_port);

	int SERVAddrSize = sizeof(serveraddr);

	printf("Socket Start ...\n");
	printf("Please input message:\n");
	char SendBuf[10020] = "\0";
	char RecvBuf[10020] = "\0";
	//system("pause"); //test

	int i_result = 0;
	
	while (true)
	{
		scanf_s("%s", SendBuf);
		if (strcmp(SendBuf, "bye") == 0)
		{
			printf("bye!");
			Sleep(1000);
			if (i_result == SOCKET_ERROR)
			{
				printf("closesocket failed with error %d\n", WSAGetLastError());
				return 1;
			}
			break;
		}

		printf("sending...\n");
		i_result = sendto(sockfd, SendBuf, sizeof(SendBuf), 0, reinterpret_cast<sockaddr*>(&serveraddr), sizeof(serveraddr));
		if (i_result == SOCKET_ERROR)
		{
			printf("recvfrom failed with error %d\n", WSAGetLastError());
			WSACleanup();
			return 1;
		}
		else
		{
			Sleep(10);
			i_result = recvfrom(sockfd, RecvBuf, sizeof(RecvBuf), 0, reinterpret_cast<sockaddr*>(&serveraddr), &SERVAddrSize);
			if (i_result == SOCKET_ERROR)
			{
				printf("recvfrom failed with error %d\n", WSAGetLastError());
				WSACleanup();
				return 1;
			}
			printf("receive message from server: %s\n", RecvBuf);
		}
	}

	i_result = closesocket(cli_socket);
	if (i_result == SOCKET_ERROR)
	{
		printf("closesocket failed with error %d\n", WSAGetLastError());
		return 1;
	}
	WSACleanup();

	system("pause");  // NOLINT(concurrency-mt-unsafe)
	return 0;
}


