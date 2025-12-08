# To learn more about how to use Nix to configure your environment
# see: https://firebase.google.com/docs/studio/customize-workspace
{ pkgs, ... }: {
  # Which nixpkgs channel to use.
  channel = "stable-24.05"; # or "unstable"

  # Use https://search.nixos.org/packages to find packages
  packages = [
    pkgs.dotnet-sdk_8
    # pkgs.go
    # pkgs.python311
    # pkgs.python311Packages.pip
    # pkgs.nodejs_20
    # pkgs.nodePackages.nodemon
  ];

  # Sets environment variables in the workspace
  env = {
    # GOPATH = "$HOME/go";
  };

  # VS Code extensions to install
  # vscodium.extensions = [
  #   "golang.go"
  #   "ms-python.python"
  #   "ms-vscode.node-debug2"
  # ];

  # Scripts to run when the workspace is started
  # startup.pre-build = [
  #   "go get -u golang.org/x/tools/gopls"
  # ];
}
