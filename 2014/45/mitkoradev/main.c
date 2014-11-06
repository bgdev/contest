#include <cstdio>
#include <cstring>

#define MAX_DIGITS 128

int translate(char*value_in,char*digits_in,char*digits_out,char*output_rev)
{
    int output_size=0;

    int base_in=strlen(digits_in);
    int base_out=strlen(digits_out);

    unsigned char lookup[256]={};

    for(int i=0;i<base_in;i++)
    lookup[(unsigned char)digits_in[i]]=i;

/**
Add the value of the first digit of source language
to the target language representation,  next multiply
the target representation by source base and add second digit, and so on...

note output_rev is reversed here, lsb first.
*/
    for(int i=0;value_in[i];i++)
    {
        int remainder=lookup[(unsigned char)value_in[i]];

        for(int j=0;(j<output_size)||(remainder);j++)
        {
            if((j==output_size)&&remainder)output_size++;

            remainder=remainder+output_rev[j]*base_in;

            output_rev[j]=remainder%base_out;
            remainder/=base_out;
        }
    }
    return output_size;
}



int main()
{
    int N=0;

    scanf(" %d",&N);

    for(int n=1;n<=N;n++)
    {
        char value_in[MAX_DIGITS]={};
        char lookup_in[MAX_DIGITS]={};
        char lookup_out[MAX_DIGITS]={};
        char output_rev[MAX_DIGITS]={};

        scanf(" %s %s %s ",value_in,lookup_in,lookup_out);

        int output_size=translate(value_in,lookup_in,lookup_out,output_rev);

        unsigned char value_out[1024]={};
        for(int j=output_size-1;j>=0;j--)
        value_out[output_size-1-j]=lookup_out[(unsigned char )output_rev[j]];

        printf("Case #%d: %s\n",n,value_out);
    }

    return 0;
}
