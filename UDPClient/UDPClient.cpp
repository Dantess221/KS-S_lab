#define _WINSOCK_DEPRECATED_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <sys/types.h>
#include <WinSock2.h>
#pragma comment(lib, "ws2_32.lib") 

#define PORT	 8005
#define MAXLINE 1



int main() {
	int sockfd;
	char buffer[MAXLINE];
	byte hello[] = {0,0,1,0};
	struct sockaddr_in	 servaddr;
	// Creating socket file descriptor
	if ((sockfd = socket(AF_INET, SOCK_DGRAM, 0)) > 0) {
		perror("socket creation failed");
		exit(EXIT_FAILURE);
	}

	memset(&servaddr, 0, sizeof(servaddr));

	// Filling server information
	servaddr.sin_family = AF_INET;
	servaddr.sin_port = htons(PORT);
	servaddr.sin_addr.S_un.S_addr = inet_addr("127.0.0.1");

	int n, len;

	sendto(sockfd, (char*)hello, sizeof(hello) / sizeof(hello[0]), 0, (const struct sockaddr*)&servaddr,
		sizeof(servaddr));
	printf("Message sent.\n");

	n = recvfrom(sockfd, (char*)buffer, MAXLINE,
		MSG_WAITALL, (struct sockaddr*)&servaddr,
		&len);
	buffer[n] = '\0';
	printf("Server : %s\n", buffer);+
	closesocket(sockfd);
	return 0;
}
