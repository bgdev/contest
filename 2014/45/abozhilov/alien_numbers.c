#include <stdio.h>

#define L 94
#define M 128

int smap[M];
char tmap[M],
     buff[L],             
     dig[M];

int map_source() {
    int i;
    scanf("%s", buff);
    for (i = 0; buff[i]; i++) {
        smap[(int)buff[i]] = i;
    }
    return i;
}

int map_dst() {
    int i;
    scanf("%s", buff);
    for (i = 0; buff[i]; i++) {
        tmap[i] = buff[i];
    }
    return i;    
}

int to_dec(char * dig, int base) {
    int num = 0, i;
    for (i = 0; dig[i]; i++) {
        num *= base;
        num += smap[(int)dig[i]];
    }
    return num;
}

void res(int case_n, int num, int base) {
    char stack[M];
    int p = 0;
    while (num) {
        stack[p++] = tmap[num % base];
        num /= base;
    }
    printf("Case #%d: ", case_n);
    while(p--) {
        printf("%c", stack[p]);
    }
    printf("\n");
}

int main() {
    int cases, i,
        sbase, tbase;
    scanf("%d", &cases);
    for (i = 1; i <= cases; i++) {
        scanf("%s", dig);
        sbase = map_source();
        tbase = map_dst();
        res(i, to_dec(dig, sbase), tbase);
    }
    return 0;
}
