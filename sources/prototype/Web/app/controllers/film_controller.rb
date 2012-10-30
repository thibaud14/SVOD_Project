class FilmController < ApplicationController
  def search
    @grants = Film.search params[:search]
  end
end
