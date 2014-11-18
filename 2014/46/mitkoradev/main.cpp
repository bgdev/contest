#include <cstdio>
#include <complex>
#include <map>


char path[2][16000];

std::map< std::pair<int,int> ,char > maze;

typedef std::complex<int> POINT;

int DirToMask(POINT dir)
{
    return
    (dir.imag()==+1)?1:
    (dir.imag()==-1)?2:
    (dir.real()==-1)?4:
    (dir.real()==+1)?8:
    0;
}

void Walk(const char*  path,POINT &pos,POINT &dir, POINT &minpt,POINT &maxpt)
{
    POINT enter_dir=dir;///enter direction for cell

    path++;
    pos+=dir;
    ///enter maze


    for(;*path;path++)
    {

        switch(*path)
        {
            case 'W':

                if(minpt.real()>pos.real())minpt.real()=pos.real();
                if(minpt.imag()>pos.imag())minpt.imag()=pos.imag();

                if(maxpt.real()<pos.real())maxpt.real()=pos.real();
                if(maxpt.imag()<pos.imag())maxpt.imag()=pos.imag();

                ///break walls in enter and exit directions
                maze[std::make_pair(pos.real(),pos.imag())]|=DirToMask(-enter_dir);
                maze[std::make_pair(pos.real(),pos.imag())]|=DirToMask(+dir);

                pos+=dir;

                enter_dir=dir;

                break;

            case 'L':
                dir*=POINT(0,1);
                break;

            case 'R':
                dir*=POINT(0,-1);
                break;
        }
    }

}

int main()
{
    /**
    Initally there are walls everywhere,
    each move breaks walls
    */
    int N=0;
    scanf("%d",&N);
    for(int k=1;k<=N;k++)
    {
        scanf("%s %s",path[0],path[1]);

        POINT minpt(0,0), maxpt(0,0);

        POINT dir(0,-1);
        POINT pos(0,1);

        Walk(path[0],pos,dir, minpt,maxpt);

        dir=-dir;
        Walk(path[1],pos,dir, minpt,maxpt);

        printf("Case #%d:\n",k);
        for(int y=maxpt.imag();y>=minpt.imag();y--)
        {
            for(int x=minpt.real();x<=maxpt.real();x++)
            printf("%x",maze[std::make_pair(x,y)]);
            printf("\n");
        }

        maze.clear();
    }

    return 0;
}
