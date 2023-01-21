m,n=list(map(int,input().split()))
matrix=[]
for i in range(m):
    inputs=list(map(int,input().split()))
    matrix.append(inputs)

a=0
for i in range(m):
    for j in range(n):
        if matrix[i][j]==1:
            if i-1>=0 and matrix[i-1][j]==1:
                continue
            elif j-1>=0 and matrix[i][j-1]==1:
                continue
            else:
                a=a+1
print(a)  
