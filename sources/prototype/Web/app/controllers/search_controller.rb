class SearchController < ApplicationController

  def find
    if !params[:search].nil?
      @video = Video.find
    end
  end

end