@echo off
echo ==========================================
echo LIMPANDO CACHE DO VISUAL STUDIO
echo ==========================================
echo.

echo 1. Limpando a pasta oculta .vs do projeto atual...
IF EXIST ".vs" (
    rmdir /S /Q ".vs"
    echo Pasta .vs removida.
) ELSE (
    echo Pasta .vs nao encontrada (ja limpa).
)

echo.
echo 2. Limpando ComponentModelCache do Visual Studio...
FOR /D %%p IN ("%LOCALAPPDATA%\Microsoft\VisualStudio\17.0_*") DO (
    IF EXIST "%%p\ComponentModelCache" (
        rmdir /S /Q "%%p\ComponentModelCache"
        echo Cache limpo em: %%p
    )
)

echo.
echo Concluido! Abra o Visual Studio e aguarde a indexacao.
pause